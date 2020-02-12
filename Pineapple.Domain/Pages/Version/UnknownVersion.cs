using System;
using System.Diagnostics.CodeAnalysis;

namespace Pineapple.Domain.Pages.Version
{
    /// <summary>
    /// Placeholder if a version is non-existent.
    /// </summary>
    [SuppressMessage("ReSharper", "SA1623", Justification = "Properties always throw, so the documentation is more accurate.")]
    public sealed class UnknownVersion : IVersion
    {
        /// <summary>
        /// Throws, since an invalid version has no content.
        /// </summary>
        public string Content => throw new NotSupportedException();

        /// <summary>
        /// Throws, since an invalid version has no creation date.
        /// </summary>
        public DateTime CreatedAt => throw new NotSupportedException();
    }
}
