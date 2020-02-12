using Pineapple.Domain.Pages;
using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Pages.Version;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Infrastructure.DataAccess.InMemory.Entities
{
    /// <inheritdoc/>
    public sealed class Page : IPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Page"/> class.
        /// </summary>
        /// <param name="space">Name of the space this page is contained in.</param>
        /// <param name="name">Name of this page.</param>
        public Page(SpaceName space, PageName name)
        {
            Space = space;
            Name = name;
            CurrentVersion = new UnknownVersion();
        }

        /// <inheritdoc/>
        public SpaceName Space { get; }

        /// <inheritdoc/>
        public PageName Name { get; }

        /// <inheritdoc/>
        public IVersion CurrentVersion { get; }
    }
}
