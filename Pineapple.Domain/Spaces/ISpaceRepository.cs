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
        /// <param name="name">name of the space</param>
        /// <returns>the space</returns>
        Task<ISpace> Get(SpaceName name);

        /// <summary>
        /// Gets the names of all spaces.
        /// </summary>
        /// <returns>space names</returns>
        Task<SpacesCollection> All();

        /// <summary>
        /// Creates a new empty space.
        /// </summary>
        /// <param name="space">space to create</param>
        /// <returns>task</returns>
        Task Add(ISpace space);
    }
}
