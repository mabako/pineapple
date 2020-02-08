#if false
using System;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Spaces;
using Pineapple.Infrastructure.DataAccess.Git;
using Pineapple.Infrastructure.DataAccess.Git.Repositories;

namespace Pineapple.IntegrationTests.TestFixtures
{
    /// <summary>
    /// Fixtures for testing git-based services.
    /// </summary>
    public sealed class GitFixtures : IDisposable
    {
        private readonly GitConfigurationFixture _configuration = new GitConfigurationFixture();
        private readonly GitEntityFactory _entityFactory;

        public GitFixtures()
        {
            _entityFactory = new GitEntityFactory();

            SpaceRepository = new SpaceRepository(_configuration.Configuration);
            PageRepository = new PageRepository();

            SpaceService = new SpaceService(SpaceFactory, SpaceRepository);
        }

        public ISpaceFactory SpaceFactory => _entityFactory;
        public IPageFactory PageFactory => _entityFactory;
        public ISpaceRepository SpaceRepository { get; }
        public IPageRepository PageRepository { get; }
        public SpaceService SpaceService { get; }

        public void Dispose()
        {
            _configuration?.Dispose();
        }
    }
}
#endif
