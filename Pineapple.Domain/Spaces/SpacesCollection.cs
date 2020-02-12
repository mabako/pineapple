using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Domain.Spaces
{
    /// <summary>
    /// A collection of space names.
    /// </summary>
    public sealed class SpacesCollection
    {
        private readonly ISet<SpaceName> _spaceNames = new HashSet<SpaceName>();

        /// <summary>
        /// Adds a list of space names.
        /// </summary>
        /// <param name="spaces">The list of space names to add.</param>
        public void Add(IEnumerable<SpaceName> spaces)
        {
            foreach (var space in spaces)
            {
                _spaceNames.Add(space);
            }
        }

        /// <summary>
        /// Adds a new space name.
        /// </summary>
        /// <param name="space">The space name to add.</param>
        public void Add(SpaceName space) => _spaceNames.Add(space);

        /// <summary>
        /// Lists all spaces, sorted alphabetically.
        /// </summary>
        /// <returns>A sorted list of spaces.</returns>
        public IReadOnlyList<SpaceName> GetSpaceNames() => new ReadOnlyCollection<SpaceName>(_spaceNames.OrderBy(x => x.ToString()).ToList());
    }
}
