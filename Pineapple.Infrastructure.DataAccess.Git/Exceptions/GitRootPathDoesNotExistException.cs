using System;

namespace Pineapple.Infrastructure.DataAccess.Git.Exceptions
{
    /// <summary>
    /// The root path is either not configured correctly or does not exist at all.
    /// </summary>
    public sealed class GitRootPathDoesNotExistException : Exception
    {
        public GitRootPathDoesNotExistException(string message)
            : base(message)
        {
        }
    }
}
