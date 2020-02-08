using Pineapple.Domain.Pages;
using Pineapple.Domain.Pages.ValueObjects;

namespace Pineapple.Infrastructure.DataAccess.InMemory.Entities
{
    /// <inheritdoc/>
    public class Page : IPage
    {
        public Page(PageName name)
        {
            Name = name;
        }

        public PageName Name { get; }
        public string Content { get; set; } = string.Empty;
    }
}
