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
        /// <param name="space">The space containing the page.</param>
        /// <param name="page">Name of the page to fetch.</param>
        /// <returns>The instance of the fetched page.</returns>
        Task<IPage> Get(ISpace space, PageName page);

        /// <summary>
        /// Creates a new page.
        /// </summary>
        /// <param name="page">The page to add to the repository.</param>
        /// <param name="version">The initial version of the page.</param>
        /// <returns>Task.</returns>
        Task Add(IPage page, IVersion version);

        /// <summary>
        /// Creates a new version of the <paramref name="page"/>.
        /// </summary>
        /// <param name="page">The page that should be updated.</param>
        /// <param name="version">A version of the page replacing the current one.</param>
        /// <returns>Task.</returns>
        Task Update(IPage page, IVersion version);
    }
}
