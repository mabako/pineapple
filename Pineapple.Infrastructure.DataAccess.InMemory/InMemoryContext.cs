using System.Collections.Generic;
using Pineapple.Infrastructure.DataAccess.InMemory.Entities;

namespace Pineapple.Infrastructure.DataAccess.InMemory
{
    /// <summary>
    /// Stores all in-memory entries.
    /// </summary>
    public sealed class InMemoryContext
    {
        public IList<Space> Spaces { get; } = new List<Space>();
    }
}
