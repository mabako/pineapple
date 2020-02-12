using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using LibGit2Sharp;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.Exceptions;
using Pineapple.Domain.Spaces.ValueObjects;
using Pineapple.Infrastructure.DataAccess.Git.Repositories;
using Pineapple.IntegrationTests.TestFixtures;
using Xunit;
using Space = Pineapple.Infrastructure.DataAccess.Git.Entities.Space;

namespace Pineapple.IntegrationTests.Git.Repositories
{
    /// <summary>
    /// Tests for <see cref="SpaceRepository"/>.
    /// </summary>
    [Trait("Category", "Git")]
    public sealed class SpaceRepositoryTests : IDisposable
    {
        private readonly GitConfigurationFixture _config;
        private readonly string _rootPath;
        private readonly SpaceRepository _repository;

        public SpaceRepositoryTests()
        {
            _config = new GitConfigurationFixture();
            _rootPath = _config.Configuration.Value.RootPath;
            _repository = new SpaceRepository(_config.Configuration);
        }

        [Fact]
        public async Task Single_Space_Can_Be_Fetched()
        {
            await _repository.Add(new Space(new SpaceName("single")));
            Space space = (Space)await _repository.Get(new SpaceName("single"));

            Assert.NotNull(space);
            Assert.Equal("single", space.Name.ToString());
            Assert.Equal(
                new DirectoryInfo(Path.Combine(_rootPath, "single")).FullName,
                space.BaseDirectory?.FullName);
        }

        [Fact]
        public async Task Fetching_Non_Existent_Space_Throws()
        {
            string name = "notthere";
            Assert.False(Directory.Exists(Path.Combine(_rootPath, name)));

            await Assert.ThrowsAsync<SpaceNotFoundException>(async () =>
                await _repository.Get(new SpaceName(name)));
        }

        [Fact]
        public async Task Fetching_Non_Git_Repository_Throws()
        {
            string name = "randomfolder";
            Directory.CreateDirectory(Path.Combine(_rootPath, name));

            await Assert.ThrowsAsync<SpaceNotFoundException>(async () =>
                await _repository.Get(new SpaceName(name)));
        }

        [SkippableFact]
        public async Task Fetching_Space_With_Different_Case_Shows_Corrects_Casing()
        {
            Skip.IfNot(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));

            Repository.Init(Path.Combine(_rootPath, "A"));

            var space = (Space)await _repository.Get(new SpaceName("a"));
            Assert.NotNull(space);
            Assert.Equal("A", space.Name.ToString());
            Assert.Equal(Path.Combine(_rootPath, "A"), space.BaseDirectory?.FullName);
        }

        [Fact]
        public async Task Creating_A_Space_Creates_An_Empty_Bare_Git_Repo()
        {
            string name = "xyz";
            await _repository.Add(new Space(new SpaceName(name)));

            Assert.True(Directory.Exists(Path.Combine(_rootPath, name)));
            Assert.True(Repository.IsValid(Path.Combine(_rootPath, name)));

            using var repo = new Repository(Path.Combine(_rootPath, name));
            Assert.True(repo.Info.IsBare);
            Assert.Empty(repo.Branches);
        }

        [Fact]
        public async Task Creating_A_Space_When_Already_Initialized_Space_Throws()
        {
            await _repository.Add(new Space(new SpaceName("x")));

            ISpace space = await _repository.Get(new SpaceName("x"));

            await Assert.ThrowsAsync<SpaceAlreadyExistsException>(async () =>
                await _repository.Add(space));
        }

        [Fact]
        public async Task Creating_An_Existing_Space_Throws()
        {
            Directory.CreateDirectory(Path.Combine(_rootPath, "xyz"));

            await Assert.ThrowsAsync<SpaceAlreadyExistsException>(async () =>
                await _repository.Add(new Space(new SpaceName("xyz"))));
        }

        [SkippableFact]
        public async Task Creating_A_Space_With_Bad_Filename_Throws()
        {
            Skip.IfNot(RuntimeInformation.IsOSPlatform(OSPlatform.Windows));

            await Assert.ThrowsAsync<UnableToCreateSpaceException>(async () =>
                await _repository.Add(new Space(new SpaceName("aux"))));
        }

        [Fact]
        public async Task Listing_Spaces_When_None_Exist_Returns_Empty_Collection()
        {
            SpacesCollection spaces = await _repository.All();
            Assert.Empty(spaces.GetSpaceNames());
        }

        [Fact]
        public async Task Listing_Spaces_With_Non_Git_Repository_Ignores_Folder()
        {
            await _repository.Add(new Space(new SpaceName("a")));
            Directory.CreateDirectory(Path.Combine(_rootPath, "b"));

            SpacesCollection spaces = await _repository.All();
            var names = spaces.GetSpaceNames();
            Assert.Single(names);
            Assert.Equal("a", names.First().ToString());
        }

        [Fact]
        public async Task Listing_Spaces_Ignores_Repositories_With_Invalid_Name()
        {
            Repository.Init(Path.Combine(_rootPath, ",,,"));

            SpacesCollection spaces = await _repository.All();
            Assert.Empty(spaces.GetSpaceNames());
        }

        public void Dispose() => _config?.Dispose();
    }
}
