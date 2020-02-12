using System;

namespace Pineapple.Domain
{
    /// <summary>
    /// Represents all error types that exist only due to the particular domain.
    /// </summary>
    public class DomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        /// <param name="message">A message explaining the reason for this exception.</param>
        /// <param name="innerException">The exception causing this message to be thrown, if available.</param>
        protected DomainException(string message, Exception? innerException = null)
            : base(message, innerException)
        {
        }
    }
}
