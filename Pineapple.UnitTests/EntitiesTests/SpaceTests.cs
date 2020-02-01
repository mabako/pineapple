using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.ValueObjects;
using Pineapple.Infrastructure.DataAccess.InMemory;
using Xunit;

namespace Pineapple.UnitTests.EntitiesTests
{
    public sealed class SpaceTests
    {
        [Fact]
        public void New_Space_Is_Empty()
        {
            var entityFactory = new InMemoryEntityFactory();

            // Arrange
            var spaceName = new SpaceName("Demo");

            // Act
            ISpace space = entityFactory.NewSpace(spaceName);

            // Assert
            Assert.Equal(space.Name, spaceName);
            Assert.Empty(space.Pages.GetPageNames());
        }
    }
}
