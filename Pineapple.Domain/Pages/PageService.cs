using System.Threading.Tasks;
using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Pages.Version;
using Pineapple.Domain.Spaces;

namespace Pineapple.Domain.Pages
{
    /// <summary>
    /// Service to operate on pages.
    /// </summary>
    public sealed class PageService
    {
        private readonly IPageFactory _pageFactory;
        private readonly IPageRepository _pageRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageService"/> class.
        /// </summary>
        /// <param name="pageFactory">The factory for creating new page entities.</param>
        /// <param name="pageRepository">The repository holding all pages.</param>
        public PageService(IPageFactory pageFactory, IPageRepository pageRepository)
        {
            _pageFactory = pageFactory;
            _pageRepository = pageRepository;
        }

        /// <summary>
        /// Creates a new page.
        /// </summary>
        /// <param name="space">The space to create the page in.</param>
        /// <param name="pageName">The name of the page-to-be.</param>
        /// <param name="content">The initial content of the new page.</param>
        /// <returns>The newly created page.</returns>
        public async Task<IPage> CreatePage(ISpace space, PageName pageName, string content)
        {
            IPage page = _pageFactory.NewPage(space, pageName);
            IVersion version = _pageFactory.NewVersion(page, content);
            await _pageRepository.Add(page, version);
            return page;
        }
    }
}
