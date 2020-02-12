using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Application.Boundaries.CreatePage
{
    public sealed class CreatePageInput : IUseCaseInput
    {
        /// <summary>
        /// Creates a new <see cref="CreatePageInput"/>.
        /// </summary>
        /// <param name="spaceName">name of the parent space</param>
        /// <param name="pageName">name of the page</param>
        /// <param name="content">content to initialize the page with</param>
        public CreatePageInput(SpaceName spaceName, PageName pageName, string content)
        {
            SpaceName = spaceName;
            PageName = pageName;
            Content = content;
        }

        /// <summary>
        /// Name of the existing space.
        /// </summary>
        public SpaceName SpaceName { get; }

        /// <summary>
        /// Name of the new page.
        /// </summary>
        public PageName PageName { get; }

        /// <summary>
        /// Content to initialize the page with.
        /// </summary>
        public string Content { get; }
    }
}
