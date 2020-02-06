using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pineapple.Application.Boundaries.ListSpaces;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.ValueObjects;
using Pineapple.Infrastructure.DataAccess.InMemory;
using Pineapple.Infrastructure.DataAccess.InMemory.Repositories;
using Pineapple.UnitTests.TestPresenters;
using Xunit;
using Space = Pineapple.Infrastructure.DataAccess.InMemory.Entities.Space;

namespace Pineapple.UnitTests.UseCaseTests.ListSpaces
{
    public sealed class ListSpacesTest
    {
        private readonly SpaceRepository _spaceRepository;
        private readonly SpaceService _spaceService;

        public ListSpacesTest()
        {
            var context = new InMemoryContext();
            var entityFactory = new InMemoryEntityFactory();
            _spaceRepository = new SpaceRepository(context);
            _spaceService = new SpaceService(entityFactory, _spaceRepository);
        }

        [Fact]
        public async Task Has_No_Spaces_By_Default()
        {
            var listSpacesPresenter = new ListSpacesPresenter();
            var useCase = new Application.UseCases.ListSpaces(listSpacesPresenter, _spaceService);

            var input = new ListSpacesInput();
            await useCase.Execute(input);

            var output = listSpacesPresenter.ListedSpaces.Single().ExistingSpaces;
            Assert.Empty(output.GetSpaceNames());
        }

        [Fact]
        public async Task Lists_Single_Space()
        {
            await _spaceRepository.Add(new Space(new SpaceName("hello")));

            var listSpacesPresenter = new ListSpacesPresenter();
            var useCase = new Application.UseCases.ListSpaces(listSpacesPresenter, _spaceService);

            var input = new ListSpacesInput();
            await useCase.Execute(input);

            var output = listSpacesPresenter.ListedSpaces.Single().ExistingSpaces;
            Assert.Equal(output.GetSpaceNames(), new List<SpaceName> { new SpaceName("hello") });
        }

        [Fact]
        public async Task Lists_Multiple_Spaces_Alphabetically()
        {
            await _spaceRepository.Add(new Space(new SpaceName("c")));
            await _spaceRepository.Add(new Space(new SpaceName("a")));
            await _spaceRepository.Add(new Space(new SpaceName("b")));

            var listSpacesPresenter = new ListSpacesPresenter();
            var useCase = new Application.UseCases.ListSpaces(listSpacesPresenter, _spaceService);

            var input = new ListSpacesInput();
            await useCase.Execute(input);

            var output = listSpacesPresenter.ListedSpaces.Single().ExistingSpaces;
            Assert.Equal(output.GetSpaceNames(), new List<SpaceName> { new SpaceName("a"), new SpaceName("b"), new SpaceName("c") });
        }
    }
}
