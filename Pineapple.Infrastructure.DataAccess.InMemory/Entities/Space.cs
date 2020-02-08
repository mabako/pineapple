using Pineapple.Domain.Pages;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Infrastructure.DataAccess.InMemory.Entities
{
    /// <inheritdoc />
    public sealed class Space : ISpace
    {
        public Space(SpaceName name)
        {
            Name = name;
        }

        public SpaceName Name { get; }
        public PagesCollection Pages { get; } = new PagesCollection();
    }
}
