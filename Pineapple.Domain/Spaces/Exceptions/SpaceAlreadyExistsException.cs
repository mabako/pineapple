namespace Pineapple.Domain.Spaces.Exceptions
{
    /// <summary>
    /// The space to create did already exist previously.
    /// </summary>
    public sealed class SpaceAlreadyExistsException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="message">A message explaining the reason for this exception.</param>
        public SpaceAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
