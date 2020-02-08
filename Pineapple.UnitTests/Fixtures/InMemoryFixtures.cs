#if false
using Pineapple.Domain.Pages;
using Pineapple.Domain.Spaces;
using Pineapple.Infrastructure.DataAccess.InMemory;
using Pineapple.Infrastructure.DataAccess.InMemory.Repositories;

namespace Pineapple.UnitTests.Fixtures
{
    public sealed class InMemoryFixtures
    {
        public InMemoryFixtures()
        {
            Context = new InMemoryContext();

            var entityFactory = new InMemoryEntityFactory();
            SpaceFactory = entityFactory;
            PageFactory = entityFactory;

            SpaceRepository = new SpaceRepository(Context);
            PageRepository = new PageRepository(Context);

            SpaceService = new SpaceService(SpaceFactory, SpaceRepository);
        }

        public InMemoryContext Context { get; }
        public ISpaceFactory SpaceFactory { get; }
        public IPageFactory PageFactory { get; }
        public ISpaceRepository SpaceRepository { get; }
        public IPageRepository PageRepository { get; }
        public SpaceService SpaceService { get; }
    }
}
#endif
