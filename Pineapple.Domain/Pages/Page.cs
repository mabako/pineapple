using Pineapple.Domain.Pages.ValueObjects;

namespace Pineapple.Domain.Pages
{
    /// <summary>
    /// A single wiki page, containing of a title and some content.
    /// </summary>
    public class Page : IPage
    {
        /// <inheritdoc/>
        public PageName Name { get; protected set; }

        /// <inheritdoc/>
        public string Content { get; protected set; }
    }
}