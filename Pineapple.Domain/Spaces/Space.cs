using Pineapple.Domain.Pages;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Domain.Spaces
{
    /// <inheritdoc/>
    public abstract class Space : ISpace
    {
        protected Space()
        {
            Pages = new PagesCollection();
        }

        /// <inheritdoc/>
        public SpaceName Name { get; protected set; }

        /// <summary>
        /// All pages contained within this space.
        /// </summary>
        public PagesCollection Pages { get; protected set; }
    }
}
