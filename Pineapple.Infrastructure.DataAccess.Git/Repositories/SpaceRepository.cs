using System;
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
        /// Creates a new <see cref="SpaceRepository"/>.
        /// </summary>
        /// <param name="configuration">the git configuration</param>
        public SpaceRepository(IOptions<GitConfiguration> configuration)
        {
            string rootPath = configuration.Value.RootPath;

            if (string.IsNullOrEmpty(rootPath))
                throw new GitRootPathDoesNotExistException("The root path for Git is not configured.");

            _physicalRootDirectory = new DirectoryInfo(rootPath);
            if (!_physicalRootDirectory.Exists)
                throw new GitRootPathDoesNotExistException($"The root path '{rootPath}' does not exist.");
        }

        public Task<ISpace> Get(SpaceName name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new space.
        /// </summary>
        /// <param name="rawSpace">the space to create</param>
        /// <returns>task</returns>
        public Task Add(ISpace rawSpace)
        {
            var space = (Space) rawSpace;

            // The base directory is only not set if the space is created using the GitEntityFactory.NewSpace.
            if (space.BaseDirectory != null)
                throw new SpaceAlreadyExistsException($"The space '{space.Name}' already exists.");

            // If the directory exists (regardless of whether or not it is an actual git repository), just assume this is a space.
            //
            // If, for some reason, it is a manually created folder, we just can't display it.
            DirectoryInfo spaceDirectory = new DirectoryInfo(Path.Combine(_physicalRootDirectory.FullName, rawSpace.Name.ToString()));
            if (spaceDirectory.Exists)
                throw new SpaceAlreadyExistsException($"The space '{space.Name}' already exists.");

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
