using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
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
        /// Creates a new <see cref="GitConfigurationFixture"/>.
        /// </summary>
        public GitConfigurationFixture()
        {
            Configuration = Options.Create(new GitConfiguration
            {
                RootPath = _testDirectory.FullPath
            });
        }

        public IOptions<GitConfiguration> Configuration { get; }

        public void Dispose()
        {
            _testDirectory?.Dispose();
        }
    }
}
