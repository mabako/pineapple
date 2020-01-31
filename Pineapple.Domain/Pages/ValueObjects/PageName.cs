using Pineapple.Domain.Pages.Exceptions;

namespace Pineapple.Domain.Pages.ValueObjects
{
    /// <summary>
    /// Name of a page.
    /// </summary>
    public struct PageName
    {
        private readonly string _name;

        /// <summary>
        /// Initializes a new <see cref="PageName"/>.
        /// </summary>
        /// <param name="name">name</param>
        public PageName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidPageNameException("No name was provided for this page.");
            
            _name = name;
        }

        public override string ToString() => _name;
    }
}