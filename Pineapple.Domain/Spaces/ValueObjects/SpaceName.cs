using System;
using System.Text.RegularExpressions;
using Pineapple.Domain.Spaces.Exceptions;

namespace Pineapple.Domain.Spaces.ValueObjects
{
    /// <summary>
    /// Name of a Space.
    /// </summary>
    public sealed class SpaceName : IEquatable<SpaceName>
    {
        private static readonly Regex ValidSpaceName = new Regex(@"^([a-zA-Z\-_]{1,32})$", RegexOptions.Compiled);

        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceName"/> class.
        /// </summary>
        /// <param name="name">A valid name for a space.</param>
        /// <exception cref="InvalidSpaceNameException">Thrown when no name is provided, or the provided name is invalid.</exception>
        public SpaceName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidSpaceNameException("No name was provided for the space.");
            }

            if (!ValidSpaceName.IsMatch(name))
            {
                throw new InvalidSpaceNameException($"The space name '{name}' is invalid.");
            }

            _name = name;
        }

        public static bool operator ==(SpaceName? left, SpaceName? right) => Equals(left, right);

        public static bool operator !=(SpaceName? left, SpaceName? right) => !Equals(left, right);

        /// <summary>
        /// Returns the name of the space.
        /// </summary>
        /// <returns>The name represented by this instance.</returns>
        public override string ToString() => _name;

        /// <inheritdoc/>
        public bool Equals(SpaceName? other)
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
            return ReferenceEquals(this, obj) || (obj is SpaceName other && Equals(other));
        }

        /// <inheritdoc/>
        public override int GetHashCode() => _name.GetHashCode();
    }
}
