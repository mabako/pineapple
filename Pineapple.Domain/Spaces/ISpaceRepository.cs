using System.Threading.Tasks;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Domain.Spaces
{
    /// <summary>
    /// Space Repository.
    /// </summary>
    public interface ISpaceRepository
    {
        /// <summary>
        /// Gets a space.
        /// </summary>
        /// <param name="name">Name of the space to fetch.</param>
        /// <returns>The instance of the fetched space.</returns>
        Task<ISpace> Get(SpaceName name);

        /// <summary>
        /// Gets the names of all spaces.
        /// </summary>
        /// <returns>A collection of all space names.</returns>
        Task<SpacesCollection> All();

        /// <summary>
        /// Creates a new empty space.
        /// </summary>
        /// <param name="space">The space to add to the repository.</param>
        /// <returns>Task.</returns>
        Task Add(ISpace space);
    }
}
