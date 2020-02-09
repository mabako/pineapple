using Pineapple.Domain.Pages;
using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Pages.Version;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Infrastructure.DataAccess.Git.Entities
{
    /// <summary>
    /// File within a git repository.
    /// </summary>
    public class Page : IPage
    {
        public Page(SpaceName space, PageName name)
        {
            Space = space;
            Name = name;
            CurrentVersion = new UnknownVersion();
        }

        public SpaceName Space { get; }
        public PageName Name { get; }
        public IVersion CurrentVersion { get; set; }
    }
}
