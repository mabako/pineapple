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
        /// Creates a new <see cref="CreatePageCommand"/>.
        /// </summary>
        /// <param name="mediator">mediator instance</param>
        public CreatePageCommand(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates the page with the given name.
        /// </summary>
        /// <param name="spaceName">name of an existing space</param>
        /// <param name="pageName">page name</param>
        /// <param name="sourceFile">file to read the new page content from</param>
        /// <returns>task</returns>
        public async Task CreatePage(SpaceName spaceName, PageName pageName, FileInfo sourceFile)
        {
            string content = await File.ReadAllTextAsync(sourceFile.FullName);

            var input = new CreatePageInput(spaceName, pageName, content);
            await _mediator.PublishAsync(input);
        }
    }
}
