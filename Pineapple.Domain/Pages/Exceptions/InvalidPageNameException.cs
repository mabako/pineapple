namespace Pineapple.Domain.Pages.Exceptions
{
    /// <summary>
    /// The name of this page is invalid.
    /// </summary>
    public sealed class InvalidPageNameException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPageNameException"/> class.
        /// </summary>
        /// <param name="message">A message explaining why the page name is invalid.</param>
        public InvalidPageNameException(string message)
            : base(message)
        {
        }
    }
}
