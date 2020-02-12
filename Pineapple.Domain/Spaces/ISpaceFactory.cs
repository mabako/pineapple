using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Domain.Spaces
{
    /// <summary>
    /// Space Factory.
    /// </summary>
    public interface ISpaceFactory
    {
        /// <summary>
        /// Creates a new space.
        /// </summary>
        /// <param name="name">The name of the space to create.</param>
        /// <returns>The newly created space.</returns>
        ISpace NewSpace(SpaceName name);
    }
}
