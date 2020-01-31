namespace Pineapple.Domain.Spaces.Exceptions
{
    /// <summary>
    /// The name for the space is invalid.
    /// </summary>
    public class InvalidSpaceNameException : DomainException
    {
        public InvalidSpaceNameException(string message) : base(message)
        {
        }
    }
}