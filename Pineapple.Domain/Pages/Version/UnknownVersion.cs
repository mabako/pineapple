using System;

namespace Pineapple.Domain.Pages.Version
{
    /// <summary>
    /// Placeholder if a version is non-existent.
    /// </summary>
    public class UnknownVersion : IVersion
    {
        public string Content => throw new NotSupportedException();
        public DateTime CreatedAt => throw new NotSupportedException();
    }
}
