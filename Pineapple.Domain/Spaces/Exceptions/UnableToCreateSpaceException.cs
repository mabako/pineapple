using System;

namespace Pineapple.Domain.Spaces.Exceptions
{
    /// <summary>
    /// We were unable to create a space due to an internal error.
    /// Trying to create a space with the same name again will most likely lead to the same result.
    /// </summary>
    public sealed class UnableToCreateSpaceException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnableToCreateSpaceException"/> class.
        /// </summary>
        /// <param name="message">A message explaining the reason for this exception.</param>
        /// <param name="innerException">The exception causing this message to be thrown.</param>
        public UnableToCreateSpaceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
