namespace Pineapple.Domain.Spaces.Exceptions
{
    /// <summary>
    /// The requested space does probably not exist.
    /// </summary>
    public sealed class SpaceNotFoundException : DomainException
    {
        public SpaceNotFoundException(string message)
            : base(message)
        {
        }
    }
}
