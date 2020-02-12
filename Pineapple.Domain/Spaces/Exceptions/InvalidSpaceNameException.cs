namespace Pineapple.Domain.Spaces.Exceptions
{
    /// <summary>
    /// The name for the space is invalid.
    /// </summary>
    public sealed class InvalidSpaceNameException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSpaceNameException"/> class.
        /// </summary>
        /// <param name="message">A message explaining why the space name is invalid.</param>
        public InvalidSpaceNameException(string message)
            : base(message)
        {
        }
    }
}
