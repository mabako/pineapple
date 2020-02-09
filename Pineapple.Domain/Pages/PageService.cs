using System;
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
        /// Creates a new instance of <see cref="PageService"/>.
        /// </summary>
        /// <param name="pageFactory">Page Factory</param>
        /// <param name="pageRepository">Page Repository</param>
        public PageService(IPageFactory pageFactory, IPageRepository pageRepository)
        {
            _pageFactory = pageFactory;
            _pageRepository = pageRepository;
        }

        /// <summary>
        /// Creates a page.
        /// </summary>
        /// <param name="space">space to create the page in</param>
        /// <param name="pageName">name of the page-to-be</param>
        /// <param name="content">content of the page</param>
        /// <returns>created page</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IPage> CreatePage(ISpace space, PageName pageName, string content)
        {
            IPage page = _pageFactory.NewPage(space, pageName);
            IVersion version = _pageFactory.NewVersion(page, content);
            await _pageRepository.Add(page, version);
            return page;
        }
    }
}
