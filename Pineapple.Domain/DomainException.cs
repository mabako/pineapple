using System;

namespace Pineapple.Domain
{
    /// <summary>
    /// Base class of all domain exceptions.
    /// </summary>
    public class DomainException : Exception
    {
        /// <summary>
        /// Initializes a new domain exception.
        /// </summary>
        /// <param name="message">message</param>
        public DomainException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new domain exception.
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="innerException">inner exception</param>
        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
