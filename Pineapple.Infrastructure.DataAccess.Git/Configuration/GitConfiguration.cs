namespace Pineapple.Infrastructure.DataAccess.Git.Configuration
{
    /// <summary>
    /// Configuration for the Git backend.
    /// </summary>
    public sealed class GitConfiguration
    {
        /// <summary>
        /// Gets or sets root path to use for git directories.
        /// </summary>
        public string RootPath { get; set; } = string.Empty;
    }
}
