using Pineapple.Domain.Pages;

namespace Pineapple.Application.Boundaries.CreatePage
{
    /// <summary>
    /// Created page output message.
    /// </summary>
    public sealed class CreatePageOutput : IUseCaseOutput
    {
        public CreatePageOutput(IPage page)
        {
            Page = page;
        }

        public IPage Page { get; }
    }
}
