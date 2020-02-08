using Pineapple.Domain.Pages;
using Pineapple.Domain.Pages.ValueObjects;

namespace Pineapple.Infrastructure.DataAccess.Git.Entities
{
    /// <summary>
    /// File within a git repository.
    /// </summary>
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
