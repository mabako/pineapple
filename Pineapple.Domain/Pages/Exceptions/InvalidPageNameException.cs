namespace Pineapple.Domain.Pages.Exceptions
{
    /// <summary>
    /// The name of this page is invalid.
    /// </summary>
    public class InvalidPageNameException : DomainException
    {
        public InvalidPageNameException(string message) 
            : base(message)
        {
        }
    }
}