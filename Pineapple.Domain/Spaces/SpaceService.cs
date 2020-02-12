using System.Threading.Tasks;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Domain.Spaces
{
    /// <summary>
    /// Connecting you to Spaces.
    /// </summary>
    public sealed class SpaceService
    {
        private readonly ISpaceFactory _spaceFactory;
        private readonly ISpaceRepository _spaceRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceService"/> class.
        /// </summary>
        /// <param name="spaceFactory">The factory for creating new space entities.</param>
        /// <param name="spaceRepository">The repository holding all spaces.</param>
        public SpaceService(ISpaceFactory spaceFactory, ISpaceRepository spaceRepository)
        {
            _spaceFactory = spaceFactory;
            _spaceRepository = spaceRepository;
        }

        /// <summary>
        /// Creates a new space.
        /// </summary>
        /// <param name="name">The name of the space-to-be.</param>
        /// <returns>The newly created space.</returns>
        public async Task<ISpace> CreateSpace(SpaceName name)
        {
            var space = _spaceFactory.NewSpace(name);
            await _spaceRepository.Add(space);
            return space;
        }

        /// <inheritdoc cref="ISpaceRepository.All"/>
        public async Task<SpacesCollection> ListSpaces()
        {
            return await _spaceRepository.All();
        }
    }
}
