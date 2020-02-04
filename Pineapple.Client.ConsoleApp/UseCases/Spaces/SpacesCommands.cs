using System.Threading.Tasks;
using FluentMediator;
using Pineapple.Application.Boundaries.CreateSpace;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Client.ConsoleApp.UseCases.Spaces
{
    /// <summary>
    /// Spaces commands to create a space.
    /// </summary>
    public sealed class SpacesCommands
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Creates a new <see cref="SpacesCommands"/>.
        /// </summary>
        /// <param name="mediator">mediator instance</param>
        public SpacesCommands(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates the space with the given name.
        /// </summary>
        /// <param name="name">space name</param>
        /// <returns>task</returns>
        public async Task CreateSpace(SpaceName name)
        {
            var input = new CreateSpaceInput(name);
            await _mediator.PublishAsync(input);
        }
    }
}
