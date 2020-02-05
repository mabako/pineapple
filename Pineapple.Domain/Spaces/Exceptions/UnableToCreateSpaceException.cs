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
        /// Creates a new <see cref="UnableToCreateSpaceException"/>.
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="innerException">inner exception</param>
        public UnableToCreateSpaceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
