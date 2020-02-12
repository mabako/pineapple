namespace Pineapple.Domain.Spaces.Exceptions
{
    /// <summary>
    /// The requested space does probably not exist.
    /// </summary>
    public sealed class SpaceNotFoundException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceNotFoundException"/> class.
        /// </summary>
        /// <param name="message">A message explaining the reason for this exception.</param>
        public SpaceNotFoundException(string message)
            : base(message)
        {
        }
    }
}
