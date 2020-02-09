using System;

namespace Pineapple.Domain.Pages.Exceptions
{
    /// <summary>
    /// We were unable to create the page due to an internal error.
    /// </summary>
    public sealed class UnableToCreatePageException : DomainException
    {
        /// <summary>
        /// Creates a new <see cref="UnableToCreatePageException"/>.
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="innerException">reason as to why this page could not be created</param>
        public UnableToCreatePageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
