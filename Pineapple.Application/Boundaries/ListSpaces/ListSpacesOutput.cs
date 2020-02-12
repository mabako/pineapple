using Pineapple.Domain.Spaces;

namespace Pineapple.Application.Boundaries.ListSpaces
{
    /// <summary>
    /// Output message containing all spaces currently in existence.
    /// </summary>
    public sealed class ListSpacesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListSpacesOutput"/> class.
        /// </summary>
        /// <param name="existingSpaces">A collection of all existing spaces.</param>
        public ListSpacesOutput(SpacesCollection existingSpaces)
        {
            ExistingSpaces = existingSpaces;
        }

        /// <summary>
        /// Gets all currently existing spaces.
        /// </summary>
        public SpacesCollection ExistingSpaces { get; }
    }
}
