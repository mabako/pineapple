using Pineapple.Domain.Pages.ValueObjects;

namespace Pineapple.Domain.Pages
{
    /// <summary>
    /// A single page in the wiki.
    /// </summary>
    public interface IPage
    {
        /// <summary>
        /// Name of this page.
        /// </summary>
        PageName Name { get; }
        
        /// <summary>
        /// Current content.
        /// </summary>
        string Content { get; }
    }
}