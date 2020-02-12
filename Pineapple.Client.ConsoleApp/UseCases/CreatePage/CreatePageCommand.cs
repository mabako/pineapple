using System.IO;
using System.Threading.Tasks;
using FluentMediator;
using Pineapple.Application.Boundaries.CreatePage;
using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Client.ConsoleApp.UseCases.CreatePage
{
    /// <summary>
    /// Command to create a new page.
    /// </summary>
    public sealed class CreatePageCommand
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePageCommand"/> class.
        /// </summary>
        /// <param name="mediator">The mediator instance to publish messages with.</param>
        public CreatePageCommand(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates the page with the given name.
        /// </summary>
        /// <param name="spaceName">Name of the space that the page should be created in.</param>
        /// <param name="pageName">Name of the page to create.</param>
        /// <param name="sourceFile">The file to read the initial page content from.</param>
        /// <returns>Task.</returns>
        public async Task CreatePage(SpaceName spaceName, PageName pageName, FileInfo sourceFile)
        {
            string content = await File.ReadAllTextAsync(sourceFile.FullName);

            var input = new CreatePageInput(spaceName, pageName, content);
            await _mediator.PublishAsync(input);
        }
    }
}
