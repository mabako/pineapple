namespace Pineapple.Domain.Spaces.Exceptions
{
    /// <summary>
    /// The space to create did already exist previously.
    /// </summary>
    public class SpaceAlreadyExistsException : DomainException
    {
        public SpaceAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
