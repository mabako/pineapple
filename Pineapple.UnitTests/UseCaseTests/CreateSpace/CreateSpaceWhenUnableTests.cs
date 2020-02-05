using System;
using System.Threading.Tasks;
using Moq;
using Pineapple.Application.Boundaries.CreateSpace;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.Exceptions;
using Pineapple.Domain.Spaces.ValueObjects;
using Pineapple.Infrastructure.DataAccess.InMemory;
using Pineapple.UnitTests.TestPresenters;
using Xunit;

namespace Pineapple.UnitTests.UseCaseTests.CreateSpace
{
    /// <summary>
    /// In particular, we have no way to (reliably, in a cross-platform way) to cause a
    /// <see cref="UnableToCreateSpaceException"/>, and even the adapters that can possibly
    /// throw such an exception may throw them for different, platform-dependent values.
    ///
    /// We do, however, still want the correct output to be triggered on the presenter.
    /// </summary>
    public sealed class CreateSpaceWhenUnableTests
    {
        [Fact]
        public async Task Creating_An_Uncreatable_Space_Fails()
        {
            // arrange
            var spaceRepository = new Mock<ISpaceRepository>();
            spaceRepository.Setup(c => c.Add(It.IsAny<ISpace>()))
                .Throws(new UnableToCreateSpaceException("nah", new Exception()));

            var entityFactory = new InMemoryEntityFactory();
            var spaceService = new SpaceService(entityFactory, spaceRepository.Object);

            var createSpacePresenter = new CreateSpacePresenter();

            var useCase = new Application.UseCases.CreateSpace(createSpacePresenter, spaceService);
            var input = new CreateSpaceInput(new SpaceName("Demo"));

            // act
            await useCase.Execute(input);

            // assert
            Assert.Single(createSpacePresenter.UnableToCreate);
            Assert.Empty(createSpacePresenter.CreatedSpaces);
            Assert.Empty(createSpacePresenter.AlreadyExisting);

            spaceRepository.Verify(c => c.Add(It.Is<ISpace>(s => s.Name.ToString() == "Demo")));
            spaceRepository.VerifyNoOtherCalls();
        }
    }
}
