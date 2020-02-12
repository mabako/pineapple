namespace Pineapple.Domain.Pages.Exceptions
{
    /// <summary>
    /// The page you tried to create already exists.
    /// </summary>
    public sealed class PageAlreadyExistsException : DomainException
    {
        /// <summary>
        /// Creates a new <see cref="PageAlreadyExistsException"/>.
        /// </summary>
        /// <param name="message">message</param>
        public PageAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
