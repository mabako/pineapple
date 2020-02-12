using System.Threading.Tasks;
using Pineapple.Application.Boundaries.CreateSpace;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.Exceptions;

namespace Pineapple.Application.UseCases
{
    /// <summary>
    /// Creates a new space.
    /// </summary>
    public sealed class CreateSpace : IUseCase
    {
        private readonly IOutputPort _outputPort;
        private readonly SpaceService _spaceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSpace"/> class.
        /// </summary>
        /// <param name="outputPort">The output port to send all messages to.</param>
        /// <param name="spaceService">The service to manage spaces.</param>
        public CreateSpace(IOutputPort outputPort, SpaceService spaceService)
        {
            _outputPort = outputPort;
            _spaceService = spaceService;
        }

        /// <inheritdoc/>
        public async Task Execute(CreateSpaceInput input)
        {
            try
            {
                ISpace space = await _spaceService.CreateSpace(input.SpaceName);
                _outputPort.Standard(new CreateSpaceOutput(space));
            }
            catch (SpaceAlreadyExistsException e)
            {
                _outputPort.SpaceAlreadyExists(e.Message);
            }
            catch (UnableToCreateSpaceException e)
            {
                _outputPort.UnableToCreateSpace(e.Message);
            }
        }
    }
}
