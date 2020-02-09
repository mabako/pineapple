using System;
using System.Threading.Tasks;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Pages.Version;
using Pineapple.Domain.Spaces;

namespace Pineapple.Infrastructure.DataAccess.Git.Repositories
{
    public sealed class PageRepository : IPageRepository
    {
        public Task<IPage> Get(ISpace space, PageName page)
        {
            throw new NotImplementedException();
        }

        public Task Add(IPage page, IVersion version)
        {
            throw new NotImplementedException();
        }

        public Task Update(IPage page, IVersion version)
        {
            throw new NotImplementedException();
        }
    }
}
