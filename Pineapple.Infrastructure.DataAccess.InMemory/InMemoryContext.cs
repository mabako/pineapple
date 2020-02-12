using System.Collections.Generic;
using Pineapple.Infrastructure.DataAccess.InMemory.Entities;

namespace Pineapple.Infrastructure.DataAccess.InMemory
{
    /// <summary>
    /// Stores all in-memory entities.
    /// </summary>
    public sealed class InMemoryContext
    {
        /// <summary>
        /// Gets all spaces existing in memory.
        /// </summary>
        public IList<Space> Spaces { get; } = new List<Space>();
    }
}
