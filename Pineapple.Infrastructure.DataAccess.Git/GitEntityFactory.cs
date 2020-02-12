using System;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Pages.Version;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Infrastructure.DataAccess.Git
{
    /// <summary>
    /// Factory for creating git-backed entities.
    /// </summary>
    public sealed class GitEntityFactory : ISpaceFactory, IPageFactory
    {
        /// <inheritdoc/>
        public ISpace NewSpace(SpaceName name) => new Entities.Space(name);

        /// <inheritdoc/>
        public IPage NewPage(ISpace space, PageName pageName) => new Entities.Page(space.Name, pageName);

        /// <inheritdoc/>
        public IVersion NewVersion(IPage page, string content)
        {
            throw new NotImplementedException();
        }
    }
}
