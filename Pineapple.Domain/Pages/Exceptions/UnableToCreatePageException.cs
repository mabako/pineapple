using System;

namespace Pineapple.Domain.Pages.Exceptions
{
    /// <summary>
    /// We were unable to create the page due to an internal error.
    /// </summary>
    public sealed class UnableToCreatePageException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnableToCreatePageException"/> class.
        /// </summary>
        /// <param name="message">A message explaining the reason for this exception.</param>
        /// <param name="innerException">The exception causing this message to be thrown.</param>
        public UnableToCreatePageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
