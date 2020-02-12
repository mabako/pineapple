namespace Pineapple.Domain.Pages.Exceptions
{
    /// <summary>
    /// The page you tried to create already exists.
    /// </summary>
    public sealed class PageAlreadyExistsException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="message">A message explaining the reason for this exception.</param>
        public PageAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
