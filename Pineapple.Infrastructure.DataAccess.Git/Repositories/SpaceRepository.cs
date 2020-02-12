using System.IO;
using System.Threading.Tasks;
using LibGit2Sharp;
using Microsoft.Extensions.Options;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.Exceptions;
using Pineapple.Domain.Spaces.ValueObjects;
using Pineapple.Infrastructure.DataAccess.Git.Configuration;
using Pineapple.Infrastructure.DataAccess.Git.Exceptions;
using Space = Pineapple.Infrastructure.DataAccess.Git.Entities.Space;

namespace Pineapple.Infrastructure.DataAccess.Git.Repositories
{
    /// <summary>
    /// Manages access to physical git repositories.
    /// </summary>
    public sealed class SpaceRepository : ISpaceRepository
    {
        private readonly DirectoryInfo _physicalRootDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceRepository"/> class.
        /// </summary>
        /// <param name="configuration">The git configuration.</param>
        public SpaceRepository(IOptions<GitConfiguration> configuration)
        {
            string rootPath = configuration.Value.RootPath;

            if (string.IsNullOrEmpty(rootPath))
            {
                throw new GitRootPathDoesNotExistException("The root path for Git is not configured.");
            }

            _physicalRootDirectory = new DirectoryInfo(rootPath);
            if (!_physicalRootDirectory.Exists)
            {
                throw new GitRootPathDoesNotExistException($"The root path '{rootPath}' does not exist.");
            }
        }

        /// <summary>
        /// Retrieves the space with the given name.
        /// </summary>
        /// <remarks>The original space name passed to this method, and the name of the returned space, may differ on case-insensitive file systems.</remarks>
        /// <param name="name">The name of the space to retrieve.</param>
        /// <returns>The space that was retrieved.</returns>
        /// <exception cref="SpaceNotFoundException">Thrown when the directory does not exist or is not a valid git repository.</exception>
        public Task<ISpace> Get(SpaceName name)
        {
            #region Windows: Try to retrieve the name with correct case sensitivity
            var fsInfo = _physicalRootDirectory.GetFileSystemInfos(name.ToString());
            string folderName = name.ToString();
            if (fsInfo.Length == 1)
            {
                folderName = fsInfo[0].Name;
            }
            #endregion

            DirectoryInfo spaceDirectory = new DirectoryInfo(Path.Combine(_physicalRootDirectory.FullName, folderName));
            if (!spaceDirectory.Exists || !Repository.IsValid(spaceDirectory.FullName))
            {
                throw new SpaceNotFoundException($"Space '{name}' does not exist.");
            }

            var space = new Space(new SpaceName(spaceDirectory.Name))
            {
                BaseDirectory = spaceDirectory,
            };

            return Task.FromResult<ISpace>(space);
        }

        /// <summary>
        /// Looks up all existing directories that we can possibly use as spaces, contained within our root path.
        /// </summary>
        /// <returns>A collection of all existing spaces.</returns>
        public Task<SpacesCollection> All()
        {
            SpacesCollection spaces = new SpacesCollection();
            foreach (DirectoryInfo directory in _physicalRootDirectory.GetDirectories())
            {
                if (!Repository.IsValid(directory.FullName))
                {
                    continue;
                }

                try
                {
                    var spaceName = new SpaceName(directory.Name);
                    spaces.Add(spaceName);
                }
                catch (InvalidSpaceNameException)
                {
                    // ignore this folder entirely
                }
            }

            return Task.FromResult(spaces);
        }

        /// <summary>
        /// Creates a new space.
        /// </summary>
        /// <param name="rawSpace">The space to add to the repository.</param>
        /// <returns>Task.</returns>
        /// <exception cref="SpaceAlreadyExistsException">The space you tried to add already exists.</exception>
        /// <exception cref="UnableToCreateSpaceException">Creating a git repository failed.</exception>
        public Task Add(ISpace rawSpace)
        {
            var space = (Space)rawSpace;

            // The base directory is only not set if the space is created using the GitEntityFactory.NewSpace.
            if (space.BaseDirectory != null)
            {
                throw new SpaceAlreadyExistsException($"The space '{space.Name}' already exists.");
            }

            // If the directory exists (regardless of whether or not it is an actual git repository), just assume this is a space.
            //
            // If, for some reason, it is a manually created folder, we just can't display it.
            DirectoryInfo spaceDirectory = new DirectoryInfo(Path.Combine(_physicalRootDirectory.FullName, rawSpace.Name.ToString()));
            if (spaceDirectory.Exists)
            {
                throw new SpaceAlreadyExistsException($"The space '{space.Name}' already exists.");
            }

            try
            {
                string repositoryPath = Repository.Init(spaceDirectory.FullName, isBare: true);
                space.BaseDirectory = new DirectoryInfo(repositoryPath);

                return Task.CompletedTask;
            }
            catch (LibGit2SharpException e)
            {
                // Could contain a few exceptions: Path too long, invalid characters (unlikely with the constraints on SpaceName), etc.
                //
                // Certain directory (or file) names simply are not valid on certain operating systems, and they're not
                // inherently "bad" names for a repository on another platform, thus disallowing them on all platforms is dubious.
                //
                // In particular, Windows has a list of backwards-compatibility names such as "aux" that the win API cannot create/open.
                throw new UnableToCreateSpaceException($"Could not create the git repository for space '{space.Name}'.", e);
            }
        }
    }
}
