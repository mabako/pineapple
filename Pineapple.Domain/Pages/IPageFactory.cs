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
        /// <param name="space">parent space</param>
        /// <param name="pageName">name of the new page</param>
        /// <returns>the new page</returns>
        IPage NewPage(ISpace space, PageName pageName);

        /// <summary>
        /// Creates a new version of a page.
        /// </summary>
        /// <param name="page">page</param>
        /// <param name="content">content to include</param>
        /// <returns>the new version</returns>
        IVersion NewVersion(IPage page, string content);
    }
}
