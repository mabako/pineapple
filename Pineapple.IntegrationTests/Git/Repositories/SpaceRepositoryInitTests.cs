using System;
using System.IO;
using Microsoft.Extensions.Options;
using Pineapple.Infrastructure.DataAccess.Git.Configuration;
using Pineapple.Infrastructure.DataAccess.Git.Exceptions;
using Pineapple.Infrastructure.DataAccess.Git.Repositories;
using Xunit;

namespace Pineapple.IntegrationTests.Git.Repositories
{
    /// <summary>
    /// Creating a repository with correct configuration is done in <see cref="SpaceRepositoryTests"/>, just check the remaining cases.
    /// </summary>
    public sealed class SpaceRepositoryInitTests
    {
        [Fact]
        public void Initializing_Repository_With_Empty_Path_Throws()
        {
            var options = Options.Create(new GitConfiguration());
            var exception = Assert.Throws<GitRootPathDoesNotExistException>(() => new SpaceRepository(options));
            Assert.Contains("is not configured", exception.Message);
        }

        [Fact]
        public void Initializing_Repository_With_Non_Existent_Path_Throws()
        {
            var path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Assert.False(Directory.Exists(path));

            var options = Options.Create(new GitConfiguration()
            {
                RootPath = path,
            });

            var exception = Assert.Throws<GitRootPathDoesNotExistException>(() => new SpaceRepository(options));
            Assert.Contains("does not exist", exception.Message);
        }
    }
}
