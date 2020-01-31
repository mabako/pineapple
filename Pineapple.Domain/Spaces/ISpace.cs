using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Domain.Spaces
{
    /// <summary>
    /// Aggregate Root for a collection of wiki pages, collectively known as Space.
    /// </summary>
    public interface ISpace
    {
        /// <summary>
        /// Name of the space, uniquely identifying it.
        /// </summary>
        SpaceName Name { get; }
    }
}