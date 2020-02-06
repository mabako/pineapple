using Pineapple.Domain.Spaces;

namespace Pineapple.Application.Boundaries.ListSpaces
{
    /// <summary>
    /// List of spaces currently in existence.
    /// </summary>
    public class ListSpacesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Creates a new <see cref="ListSpacesOutput"/>.
        /// </summary>
        /// <param name="existingSpaces">all existing spaces</param>
        public ListSpacesOutput(SpacesCollection existingSpaces)
        {
            ExistingSpaces = existingSpaces;
        }

        /// <summary>
        /// All currently existing spaces.
        /// </summary>
        public SpacesCollection ExistingSpaces { get; }
    }
}
