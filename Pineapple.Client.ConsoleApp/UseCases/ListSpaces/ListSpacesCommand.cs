using System.Threading.Tasks;
using FluentMediator;
using Pineapple.Application.Boundaries.ListSpaces;

namespace Pineapple.Client.ConsoleApp.UseCases.ListSpaces
{
    /// <summary>
    /// Command to list all spaces.
    /// </summary>
    public class ListSpacesCommand
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Creates a new <see cref="ListSpacesCommand"/>.
        /// </summary>
        /// <param name="mediator">mediator</param>
        public ListSpacesCommand(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lists all existing spaces.
        /// </summary>
        /// <returns>task</returns>
        public async Task ListSpaces()
        {
            var input = new ListSpacesInput();
            await _mediator.PublishAsync(input);
        }
    }
}
