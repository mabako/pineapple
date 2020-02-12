using System;

namespace Pineapple.Infrastructure.DataAccess.Git.Exceptions
{
    /// <summary>
    /// The root path is either not configured correctly or does not exist at all.
    /// </summary>
    public sealed class GitRootPathDoesNotExistException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GitRootPathDoesNotExistException"/> class.
        /// </summary>
        /// <param name="message">A message explaining the reason for this exception.</param>
        public GitRootPathDoesNotExistException(string message)
            : base(message)
        {
        }
    }
}
