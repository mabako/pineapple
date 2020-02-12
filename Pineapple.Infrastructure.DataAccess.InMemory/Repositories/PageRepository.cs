using System;
using System.Threading.Tasks;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Pages.Version;
using Pineapple.Domain.Spaces;

namespace Pineapple.Infrastructure.DataAccess.InMemory.Repositories
{
    /// <inheritdoc />
    public sealed class PageRepository : IPageRepository
    {
        private readonly InMemoryContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageRepository"/> class.
        /// </summary>
        /// <param name="context">The context holding all in-memory entities.</param>
        public PageRepository(InMemoryContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Task<IPage> Get(ISpace space, PageName page)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task Add(IPage page, IVersion version)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task Update(IPage page, IVersion version)
        {
            throw new NotImplementedException();
        }
    }
}
