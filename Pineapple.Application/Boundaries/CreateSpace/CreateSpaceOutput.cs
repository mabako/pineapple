using Pineapple.Domain.Spaces;

namespace Pineapple.Application.Boundaries.CreateSpace
{
    /// <summary>
    /// Output message for the successful creation of a space.
    /// </summary>
    public sealed class CreateSpaceOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSpaceOutput"/> class.
        /// </summary>
        /// <param name="space">The instance of the space that was created.</param>
        public CreateSpaceOutput(ISpace space)
        {
            Space = space;
        }

        /// <summary>
        /// Gets the instance of the space that was created.
        /// </summary>
        public ISpace Space { get; }
    }
}
