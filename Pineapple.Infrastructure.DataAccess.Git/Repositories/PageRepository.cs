using System;
using System.Threading.Tasks;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Spaces;

namespace Pineapple.Infrastructure.DataAccess.Git.Repositories
{
    public sealed class PageRepository : IPageRepository
    {
        public Task<IPage> Get(ISpace space, PageName page)
        {
            throw new NotImplementedException();
        }

        public Task Update(ISpace space, IPage page)
        {
            throw new NotImplementedException();
        }
    }
}
