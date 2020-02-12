using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Pages.Version;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Domain.Pages
{
    /// <summary>
    /// A single page in the wiki.
    /// </summary>
    public interface IPage
    {
        /// <summary>
        /// Gets the space this page exists in.
        /// </summary>
        SpaceName Space { get; }

        /// <summary>
        /// Gets name of this page.
        /// </summary>
        PageName Name { get; }

        /// <summary>
        /// Gets the current version of this page.
        /// </summary>
        IVersion CurrentVersion { get; }
    }
}
