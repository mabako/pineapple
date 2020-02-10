using System;
using Pineapple.Domain.Pages.Exceptions;

namespace Pineapple.Domain.Pages.ValueObjects
{
    /// <summary>
    /// Name of a page.
    /// </summary>
    public sealed class PageName : IEquatable<PageName>
    {
        private readonly string _name;

        /// <summary>
        /// Initializes a new <see cref="PageName"/>.
        /// </summary>
        /// <param name="name">name</param>
        public PageName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidPageNameException("No name was provided for this page.");

            _name = name;
        }

        public override string ToString() => _name;

        public bool Equals(PageName? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _name == other._name;
        }

        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) || obj is PageName other && Equals(other);
        }

        public override int GetHashCode() => _name.GetHashCode();

        public static bool operator ==(PageName? left, PageName? right) => Equals(left, right);

        public static bool operator !=(PageName? left, PageName? right) => !Equals(left, right);
    }
}
