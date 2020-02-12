using System.Threading.Tasks;
using Pineapple.Application.Boundaries.CreatePage;
using Pineapple.Domain.Pages;
using Pineapple.Domain.Pages.Exceptions;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.Exceptions;

namespace Pineapple.Application.UseCases
{
    /// <summary>
    /// Creates a new page.
    /// </summary>
    public sealed class CreatePage : IUseCase
    {
        private readonly IOutputPort _outputPort;
        private readonly ISpaceRepository _spaceRepository;
        private readonly PageService _pageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePage"/> class.
        /// </summary>
        /// <param name="outputPort">The output port to send all messages to.</param>
        /// <param name="spaceRepository">The repository holding all spaces.</param>
        /// <param name="pageService">The service to manage pages.</param>
        public CreatePage(IOutputPort outputPort, ISpaceRepository spaceRepository, PageService pageService)
        {
            _outputPort = outputPort;
            _spaceRepository = spaceRepository;
            _pageService = pageService;
        }

        /// <inheritdoc/>
        public async Task Execute(CreatePageInput input)
        {
            try
            {
                ISpace space = await _spaceRepository.Get(input.SpaceName);
                IPage page = await _pageService.CreatePage(space, input.PageName, input.Content);

                _outputPort.Standard(new CreatePageOutput(page));
            }
            catch (SpaceNotFoundException e)
            {
                _outputPort.SpaceNotFound(e.Message);
            }
            catch (PageAlreadyExistsException e)
            {
                _outputPort.PageAlreadyExists(e.Message);
            }
            catch (UnableToCreatePageException e)
            {
                _outputPort.UnableToCreatePage(e.Message);
            }
        }
    }
}
