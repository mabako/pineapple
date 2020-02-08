using System.IO;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Infrastructure.DataAccess.Git.Entities
{
    /// <summary>
    /// A self-contained git repository, representing a space within the wiki.
    /// </summary>
    public sealed class Space : ISpace
    {
        /// <summary>
        /// Creates a new <see cref="Space"/>.
        /// </summary>
        /// <param name="name">space name</param>
        public Space(SpaceName name)
        {
            Name = name;
        }

        public SpaceName Name { get; }
        public DirectoryInfo? BaseDirectory { get; set; }
        public PagesCollection Pages { get; } = new PagesCollection();
    }
}
