using Pineapple.Domain.Spaces;

namespace Pineapple.Application.Boundaries.CreateSpace
{
    /// <summary>
    /// Create Space output message.
    /// </summary>
    public sealed class CreateSpaceOutput : IUseCaseOutput
    {
        public CreateSpaceOutput(ISpace space)
        {
            Space = space;
        }

        public ISpace Space { get; }
    }
}
