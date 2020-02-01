using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Infrastructure.DataAccess.InMemory.Entities
{
    /// <inheritdoc />
    public sealed class Space : Domain.Spaces.Space
    {
        public Space(SpaceName name)
        {
            Name = name;
        }
    }
}
