using System;

namespace Pineapple.Domain.Pages.Version
{
    /// <summary>
    /// Version of a page, at a point-in-time.
    /// </summary>
    public interface IVersion
    {
        /// <summary>
        /// Gets content of the page at a point in time.
        /// </summary>
        string Content { get; }

        /// <summary>
        /// Gets when this version of the page was created.
        /// </summary>
        DateTime CreatedAt { get; }
    }
}
