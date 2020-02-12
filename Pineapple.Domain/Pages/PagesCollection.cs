using System.Collections.Generic;
using System.Collections.ObjectModel;
using Pineapple.Domain.Pages.ValueObjects;

namespace Pineapple.Domain.Pages
{
    /// <summary>
    /// A collection of page names, typically within a space.
    /// </summary>
    public sealed class PagesCollection
    {
        private readonly IList<PageName> _pageNames = new List<PageName>();

        /// <summary>
        /// Adds a list of page names.
        /// </summary>
        /// <param name="pages">The list of page names to add.</param>
        public void Add(IEnumerable<PageName> pages)
        {
            foreach (var page in pages)
            {
                Add(page);
            }
        }

        /// <summary>
        /// Adds a new page name.
        /// </summary>
        /// <param name="page">The page name to add.</param>
        public void Add(PageName page) => _pageNames.Add(page);

        /// <summary>
        /// Lists all pages names.
        /// </summary>
        /// <returns>All currently existing page names.</returns>
        public IReadOnlyCollection<PageName> GetPageNames() => new ReadOnlyCollection<PageName>(_pageNames);
    }
}
