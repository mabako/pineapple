using System;
using System.Threading.Tasks;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Infrastructure.DataAccess.InMemory.Repositories
{
    public sealed class SpaceRepository : ISpaceRepository
    {
        public Task<ISpace> Get(SpaceName name)
        {
            throw new NotImplementedException();
        }

        public Task Add(ISpace space)
        {
            throw new NotImplementedException();
        }
    }
}
