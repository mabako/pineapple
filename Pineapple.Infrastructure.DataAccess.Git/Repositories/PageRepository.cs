using System;
using System.Threading.Tasks;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Pages.Version;
using Pineapple.Domain.Spaces;

namespace Pineapple.Infrastructure.DataAccess.Git.Repositories
{
    /// <inheritdoc />
    public sealed class PageRepository : IPageRepository
    {
        /// <inheritdoc/>
        public Task<IPage> Get(ISpace space, PageName page)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task Add(IPage page, IVersion version)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task Update(IPage page, IVersion version)
        {
            throw new NotImplementedException();
        }
    }
}
