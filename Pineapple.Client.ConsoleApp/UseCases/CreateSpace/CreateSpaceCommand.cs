using System.Threading.Tasks;
using FluentMediator;
using Pineapple.Application.Boundaries.CreateSpace;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Client.ConsoleApp.UseCases.CreateSpace
{
    /// <summary>
    /// Command to create a new space.
    /// </summary>
    public sealed class CreateSpaceCommand
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSpaceCommand"/> class.
        /// </summary>
        /// <param name="mediator">The mediator instance to publish messages with.</param>
        public CreateSpaceCommand(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates the space with the given name.
        /// </summary>
        /// <param name="name">The name of the new space to create.</param>
        /// <returns>Task.</returns>
        public async Task CreateSpace(SpaceName name)
        {
            var input = new CreateSpaceInput(name);
            await _mediator.PublishAsync(input);
        }
    }
}
