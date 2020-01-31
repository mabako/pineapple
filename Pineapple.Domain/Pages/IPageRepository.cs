using System.Threading.Tasks;
using Pineapple.Domain.Pages.ValueObjects;
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
        /// Updates the <paramref name="page"/> within the <paramref name="space"/>.
        /// </summary>
        /// <param name="space">space containing the page</param>
        /// <param name="page">page to update</param>
        /// <returns>task</returns>
        // TODO we should very likely pass an IPageEdit/IPageRevision here that contains PageName,author,content; and maybe return the updated IPage -- or differentiate between "add page" and "update page" in some way
        Task Update(ISpace space, IPage page);
    }
}
