using System.Threading.Tasks;
using Pineapple.Application.Boundaries.ListSpaces;
using Pineapple.Domain.Spaces;

namespace Pineapple.Application.UseCases
{
    /// <summary>
    /// Lists all existing spaces.
    /// </summary>
    public sealed class ListSpaces : IUseCase
    {
        private readonly IOutputPort _outputPort;
        private readonly SpaceService _spaceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListSpaces"/> class.
        /// </summary>
        /// <param name="outputPort">The output port to send all messages to.</param>
        /// <param name="spaceService">The service managing spaces.</param>
        public ListSpaces(IOutputPort outputPort, SpaceService spaceService)
        {
            _outputPort = outputPort;
            _spaceService = spaceService;
        }

        /// <inheritdoc/>
        public async Task Execute(ListSpacesInput input)
        {
            SpacesCollection spaces = await _spaceService.ListSpaces();
            _outputPort.Standard(new ListSpacesOutput(spaces));
        }
    }
}
