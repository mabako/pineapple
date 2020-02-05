using System.IO;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Infrastructure.DataAccess.Git.Entities
{
    /// <summary>
    /// A self-contained git repository, representing a space within the wiki.
    /// </summary>
    public sealed class Space : Domain.Spaces.Space
    {
        /// <summary>
        /// Creates a new <see cref="Space"/>.
        /// </summary>
        /// <param name="name">space name</param>
        public Space(SpaceName name)
        {
            Name = name;
        }

        public DirectoryInfo BaseDirectory { get; set; }
    }
}
