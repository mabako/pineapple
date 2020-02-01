using System;
using System.Threading.Tasks;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Infrastructure.DataAccess.InMemory.Repositories
{
    public sealed class PageRepository : IPageRepository
    {
        private readonly InMemoryContext _context;

        public PageRepository(InMemoryContext context)
        {
            _context = context;
        }

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
