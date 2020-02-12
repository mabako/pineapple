using Pineapple.Domain.Pages;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Infrastructure.DataAccess.InMemory.Entities
{
    /// <inheritdoc />
    public sealed class Space : ISpace
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Space"/> class.
        /// </summary>
        /// <param name="name">The name of this space.</param>
        public Space(SpaceName name)
        {
            Name = name;
        }

        /// <inheritdoc/>
        public SpaceName Name { get; }

        /// <inheritdoc/>
        public PagesCollection Pages { get; } = new PagesCollection();
    }
}
