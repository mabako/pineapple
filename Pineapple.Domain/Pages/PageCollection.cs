using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pineapple.Domain.Pages
{
    /// <summary>
    /// Pages (first-class collection).
    /// </summary>
    public sealed class PageCollection
    {
        private readonly IList<IPage> _pages = new List<IPage>();

        /// <summary>
        /// Adds a list of pages.
        /// </summary>
        /// <param name="pages">the list of pages</param>
        /// <typeparam name="T">a page implementation</typeparam>
        public void Add<T>(IEnumerable<T> pages)
            where T : IPage
        {
            foreach (var page in pages)
                Add(page);
        }

        /// <summary>
        /// Adds a new page.
        /// </summary>
        /// <param name="page">page to add</param>
        public void Add(IPage page) => _pages.Add(page);

        /// <summary>
        /// Lists all pages.
        /// </summary>
        /// <returns>pages (read-only)</returns>
        public IReadOnlyCollection<IPage> GetPages() => new ReadOnlyCollection<IPage>(_pages);
    }
}
