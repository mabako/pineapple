using Pineapple.Domain.Pages;
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

        /// <summary>
        /// All pages contained within this space.
        /// </summary>
        PageCollection Pages { get; }
    }
}
