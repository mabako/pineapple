using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Application.Boundaries.CreatePage
{
    /// <summary>
    /// Input message to create a new page.
    /// </summary>
    public sealed class CreatePageInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePageInput"/> class.
        /// </summary>
        /// <param name="spaceName">Name of the space that the page should be created in.</param>
        /// <param name="pageName">Name of the page to create.</param>
        /// <param name="content">Initial content of the newly created page.</param>
        public CreatePageInput(SpaceName spaceName, PageName pageName, string content)
        {
            SpaceName = spaceName;
            PageName = pageName;
            Content = content;
        }

        /// <summary>
        /// Gets name of the space that the page should be created in.
        /// </summary>
        public SpaceName SpaceName { get; }

        /// <summary>
        /// Gets name of the page to create.
        /// </summary>
        public PageName PageName { get; }

        /// <summary>
        /// Gets the initial content of the newly created page.
        /// </summary>
        public string Content { get; }
    }
}
