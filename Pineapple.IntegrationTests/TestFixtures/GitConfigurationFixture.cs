using System;
using Microsoft.Extensions.Options;
using Pineapple.Infrastructure.DataAccess.Git.Configuration;

namespace Pineapple.IntegrationTests.TestFixtures
{
    /// <summary>
    /// Git configuration, as fixture.
    /// </summary>
    public sealed class GitConfigurationFixture : IDisposable
    {
        private readonly TestDirectory _testDirectory = new TestDirectory();

        /// <summary>
        /// Initializes a new instance of the <see cref="GitConfigurationFixture"/> class.
        /// </summary>
        public GitConfigurationFixture()
        {
            Configuration = Options.Create(new GitConfiguration
            {
                RootPath = _testDirectory.FullPath,
            });
        }

        public IOptions<GitConfiguration> Configuration { get; }

        public void Dispose()
        {
            _testDirectory?.Dispose();
        }
    }
}
