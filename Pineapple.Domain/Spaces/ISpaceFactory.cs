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
        /// <param name="name">name of the space</param>
        /// <returns>the new space</returns>
        ISpace NewSpace(SpaceName name);
    }
}
