using System.Threading.Tasks;
using FluentMediator;
using Pineapple.Application.Boundaries.ListSpaces;

namespace Pineapple.Client.ConsoleApp.UseCases.ListSpaces
{
    /// <summary>
    /// Command to list all spaces.
    /// </summary>
    public sealed class ListSpacesCommand
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListSpacesCommand"/> class.
        /// </summary>
        /// <param name="mediator">The mediator instance to publish messages with.</param>
        public ListSpacesCommand(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lists all existing spaces.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task ListSpaces()
        {
            var input = new ListSpacesInput();
            await _mediator.PublishAsync(input);
        }
    }
}
