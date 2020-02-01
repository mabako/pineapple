using System.Collections.Generic;
using System.Collections.ObjectModel;
using Pineapple.Domain.Pages.ValueObjects;

namespace Pineapple.Domain.Pages
{
    /// <summary>
    /// Pages (first-class collection).
    /// </summary>
    public sealed class PageCollection
    {
        private readonly IList<PageName> _pageNames = new List<PageName>();

        /// <summary>
        /// Adds a list of pages.
        /// </summary>
        /// <param name="pages">the list of pages</param>
        /// <typeparam name="T">a page implementation</typeparam>
        public void Add(IEnumerable<PageName> pages)
        {
            foreach (var page in pages)
                Add(page);
        }

        /// <summary>
        /// Adds a new page.
        /// </summary>
        /// <param name="page">page to add</param>
        public void Add(PageName page) => _pageNames.Add(page);

        /// <summary>
        /// Lists all pages.
        /// </summary>
        /// <returns>pages (read-only)</returns>
        public IReadOnlyCollection<PageName> GetPageNames() => new ReadOnlyCollection<PageName>(_pageNames);
    }
}
