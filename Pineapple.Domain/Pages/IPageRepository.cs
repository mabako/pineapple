using System.Threading.Tasks;
using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Pages.Version;
using Pineapple.Domain.Spaces;

namespace Pineapple.Domain.Pages
{
    /// <summary>
    /// Page Repository.
    /// </summary>
    public interface IPageRepository
    {
        /// <summary>
        /// Gets a page.
        /// </summary>
        /// <param name="space">space containing the page</param>
        /// <param name="page">page to display</param>
        /// <returns>the page</returns>
        Task<IPage> Get(ISpace space, PageName page);

        /// <summary>
        /// Creates a new page.
        /// </summary>
        /// <param name="page">page name</param>
        /// <param name="version">content to include in the current version</param>
        /// <returns>the created page</returns>
        Task Add(IPage page, IVersion version);

        /// <summary>
        /// Creates a new version of the <paramref name="page"/>.
        /// </summary>
        /// <param name="page">page to update</param>
        /// <param name="version">content to include in the (new) version</param>
        /// <returns>task</returns>
        Task Update(IPage page, IVersion version);
    }
}
