using System.Text.RegularExpressions;
using Pineapple.Domain.Spaces.Exceptions;

namespace Pineapple.Domain.Spaces.ValueObjects
{
    /// <summary>
    /// Name of a Space.
    /// </summary>
    public struct SpaceName
    {
        private static readonly Regex ValidSpaceName = new Regex(@"^([a-zA-Z\-_]{1,32})$", RegexOptions.Compiled);

        private readonly string _name;

        /// <summary>
        /// Initializes a new <see cref="SpaceName"/>.
        /// </summary>
        /// <param name="name">name</param>
        public SpaceName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidSpaceNameException("No name was provided for the space.");

            if (!ValidSpaceName.IsMatch(name))
                throw new InvalidSpaceNameException($"The space name '{name}' is invalid.");

            _name = name;
        }

        public override string ToString() => _name;
    }
}
