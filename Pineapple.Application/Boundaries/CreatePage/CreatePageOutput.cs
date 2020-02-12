using Pineapple.Domain.Pages;

namespace Pineapple.Application.Boundaries.CreatePage
{
    /// <summary>
    /// Output message for the successful creation of a page.
    /// </summary>
    public sealed class CreatePageOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePageOutput"/> class.
        /// </summary>
        /// <param name="page">The instance of the page that was created.</param>
        public CreatePageOutput(IPage page)
        {
            Page = page;
        }

        /// <summary>
        /// Gets the instance of the page that was created.
        /// </summary>
        public IPage Page { get; }
    }
}
