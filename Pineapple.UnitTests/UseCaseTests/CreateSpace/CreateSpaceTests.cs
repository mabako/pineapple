using System.Linq;
using System.Threading.Tasks;
using Pineapple.Application.Boundaries.CreateSpace;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.ValueObjects;
using Pineapple.Infrastructure.DataAccess.InMemory;
using Pineapple.Infrastructure.DataAccess.InMemory.Repositories;
using Pineapple.UnitTests.TestPresenters;
using Xunit;

namespace Pineapple.UnitTests.UseCaseTests.CreateSpace
{
    public sealed class CreateSpaceTests
    {
        private readonly SpaceRepository _spaceRepository;
        private readonly SpaceService _spaceService;

        public CreateSpaceTests()
        {
            var context = new InMemoryContext();
            var entityFactory = new InMemoryEntityFactory();
            _spaceRepository = new SpaceRepository(context);
            _spaceService = new SpaceService(entityFactory, _spaceRepository);
        }

        [Fact]
        public async Task New_Space_Should_Be_Creatable()
        {
            var createSpacePresenter = new CreateSpacePresenter();
            var useCase = new Application.UseCases.CreateSpace(createSpacePresenter, _spaceService);

            var input = new CreateSpaceInput(new SpaceName("Demo"));
            await useCase.Execute(input);

            var createdSpace = createSpacePresenter.CreatedSpaces.Single().Space;
            Assert.NotNull(createdSpace);
            Assert.Equal(input.SpaceName, createdSpace.Name);
            Assert.Empty(createSpacePresenter.AlreadyExisting);
            Assert.Empty(createSpacePresenter.UnableToCreate);
        }

        [Fact]
        public async Task Creating_The_Same_Space_Twice_Already_Exists()
        {
            var createSpacePresenter = new CreateSpacePresenter();

            var useCase1 = new Application.UseCases.CreateSpace(createSpacePresenter, _spaceService);
            var input1 = new CreateSpaceInput(new SpaceName("Demo"));
            await useCase1.Execute(input1);

            var useCase2 = new Application.UseCases.CreateSpace(createSpacePresenter, _spaceService);
            var input2 = new CreateSpaceInput(new SpaceName("Demo"));
            await useCase2.Execute(input2);

            Assert.Single(createSpacePresenter.CreatedSpaces);
            Assert.Single(createSpacePresenter.AlreadyExisting);
            Assert.Empty(createSpacePresenter.UnableToCreate);
        }

        [Fact]
        public async Task Space_Is_Retrievable_After_Creation()
        {
            var createSpacePresenter = new CreateSpacePresenter();
            var useCase = new Application.UseCases.CreateSpace(createSpacePresenter, _spaceService);

            var input = new CreateSpaceInput(new SpaceName("Demo"));
            await useCase.Execute(input);

            Assert.Single(createSpacePresenter.CreatedSpaces);

            ISpace createdSpace = await _spaceRepository.Get(new SpaceName("Demo"));
            Assert.Equal("Demo", createdSpace.Name.ToString());
        }
    }
}
