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
        /// Creates a new instance of <see cref="SpaceService"/>.
        /// </summary>
        /// <param name="spaceFactory">Space Factory</param>
        /// <param name="spaceRepository">Space Repository</param>
        public SpaceService(ISpaceFactory spaceFactory, ISpaceRepository spaceRepository)
        {
            _spaceFactory = spaceFactory;
            _spaceRepository = spaceRepository;
        }

        /// <summary>
        /// Creates a space.
        /// </summary>
        /// <param name="name">name of the space-to-be</param>
        /// <returns>created space</returns>
        public async Task<ISpace> CreateSpace(SpaceName name)
        {
            var space = _spaceFactory.NewSpace(name);
            await _spaceRepository.Add(space);
            return space;
        }

        /// <summary>
        /// Lists all existing spaces.
        /// </summary>
        /// <returns>all spaces</returns>
        public async Task<SpacesCollection> ListSpaces()
        {
            return await _spaceRepository.All();
        }
    }
}
