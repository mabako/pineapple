namespace Pineapple.Domain.Spaces.Exceptions
{
    /// <summary>
    /// The space to create did already exist previously.
    /// </summary>
    public sealed class SpaceAlreadyExistsException : DomainException
    {
        public SpaceAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
