using System;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Infrastructure.DataAccess.InMemory
{
    /// <summary>
    /// Factory for creating in memory entities.
    /// </summary>
    public sealed class InMemoryEntityFactory : ISpaceFactory, IPageFactory
    {
        public ISpace NewSpace(SpaceName name) => new Entities.Space(name);

        public IPage NewPage(ISpace space, PageName pageName)
        {
            throw new NotImplementedException();
        }
    }
}
