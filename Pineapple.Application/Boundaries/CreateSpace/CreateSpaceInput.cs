using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Application.Boundaries.CreateSpace
{
    /// <summary>
    /// Input message to create a new space.
    /// </summary>
    public sealed class CreateSpaceInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSpaceInput"/> class.
        /// </summary>
        /// <param name="spaceName">The name of the space to create.</param>
        public CreateSpaceInput(SpaceName spaceName)
        {
            SpaceName = spaceName;
        }

        /// <summary>
        /// Gets the name of the space to create.
        /// </summary>
        public SpaceName SpaceName { get; }
    }
}
