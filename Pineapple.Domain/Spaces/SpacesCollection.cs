using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Domain.Spaces
{
    /// <summary>
    /// Spaces (first-class collection).
    /// </summary>
    public sealed class SpacesCollection
    {
        private readonly ISet<SpaceName> _spaceNames = new HashSet<SpaceName>();

        /// <summary>
        /// Adds a list of spaces.
        /// </summary>
        /// <param name="spaces">the list of spaces to add</param>
        public void Add(IEnumerable<SpaceName> spaces)
        {
            foreach (var space in spaces)
                _spaceNames.Add(space);
        }

        /// <summary>
        /// Adds a new space.
        /// </summary>
        /// <param name="space">space to add</param>
        public void Add(SpaceName space) => _spaceNames.Add(space);

        /// <summary>
        /// Lists all spaces, sorted alphabetically.
        /// </summary>
        /// <returns>spaces (read-only)</returns>
        public IReadOnlyList<SpaceName> GetSpaceNames() => new ReadOnlyCollection<SpaceName>(_spaceNames.OrderBy(x => x.ToString()).ToList());
    }
}
