using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Pages.Version;
using Pineapple.Domain.Spaces;

namespace Pineapple.Domain.Pages
{
    /// <summary>
    /// Page Factory.
    /// </summary>
    public interface IPageFactory
    {
        /// <summary>
        /// Creates a new page.
        /// </summary>
        /// <param name="space">The space containing the new page.</param>
        /// <param name="pageName">The name of the page to create.</param>
        /// <returns>The newly created page.</returns>
        IPage NewPage(ISpace space, PageName pageName);

        /// <summary>
        /// Creates a new version of a page.
        /// </summary>
        /// <param name="page">The page to modify.</param>
        /// <param name="content">The content to replace the current page with.</param>
        /// <returns>The newly created version.</returns>
        IVersion NewVersion(IPage page, string content);
    }
}
