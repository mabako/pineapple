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
        /// Initializes a new instance of the <see cref="PageName"/> class.
        /// </summary>
        /// <param name="name">A valid name for a page.</param>
        /// <exception cref="InvalidPageNameException">Thrown when no name is provided.</exception>
        public PageName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidPageNameException("No name was provided for this page.");
            }

            _name = name;
        }

        public static bool operator ==(PageName? left, PageName? right) => Equals(left, right);

        public static bool operator !=(PageName? left, PageName? right) => !Equals(left, right);

        /// <summary>
        /// Returns the name of the page.
        /// </summary>
        /// <returns>The name represented by this instance.</returns>
        public override string ToString() => _name;

        /// <inheritdoc/>
        public bool Equals(PageName? other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return _name == other._name;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) || (obj is PageName other && Equals(other));
        }

        /// <inheritdoc/>
        public override int GetHashCode() => _name.GetHashCode();
    }
}
