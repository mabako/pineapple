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
        /// Initializes a new instance of the <see cref="Space"/> class.
        /// </summary>
        /// <param name="name">The name of the space.</param>
        public Space(SpaceName name)
        {
            Name = name;
        }

        /// <inheritdoc/>
        public SpaceName Name { get; }

        /// <summary>
        /// Gets or sets the base directory of the git repository backing this space.
        /// </summary>
        public DirectoryInfo? BaseDirectory { get; set; }

        /// <inheritdoc/>
        public PagesCollection Pages { get; } = new PagesCollection();
    }
}
