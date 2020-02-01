using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Application.Boundaries.CreateSpace
{
    /// <summary>
    /// Create Space input message.
    /// </summary>
    public sealed class CreateSpaceInput : IUseCaseInput
    {
        /// <summary>
        /// Creates a new <see cref="CreateSpaceInput"/>.
        /// </summary>
        /// <param name="spaceName">space name</param>
        public CreateSpaceInput(SpaceName spaceName)
        {
            SpaceName = spaceName;
        }

        public SpaceName SpaceName { get; }
    }
}
