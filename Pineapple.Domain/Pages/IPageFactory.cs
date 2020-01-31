using Pineapple.Domain.Pages.ValueObjects;
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
    }
}
