namespace Pineapple.Domain.Spaces.Exceptions
{
    /// <summary>
    /// The name for the space is invalid.
    /// </summary>
    public sealed class InvalidSpaceNameException : DomainException
    {
        public InvalidSpaceNameException(string message)
            : base(message)
        {
        }
    }
}
