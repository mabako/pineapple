using System.Threading.Tasks;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pineapple.Application.Boundaries.ListSpaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Pineapple.Client.Web.React.UseCases.V1.ListSpaces
{
    /// <summary>
    /// Controller to list spaces.
    /// </summary>
    [Route("$/api/v1/spaces")]
    [Produces("application/json")]
    [ApiController]
    public class ListSpacesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ListSpacesPresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListSpacesController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator instance to publish messages with.</param>
        /// <param name="presenter">Presenter for the use case.</param>
        public ListSpacesController(IMediator mediator, ListSpacesPresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Lists all spaces.
        /// </summary>
        /// <returns>A list of all existing space names.</returns>
        [SwaggerOperation(Tags = new[] { "Spaces" })]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListSpacesResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult?> Index()
        {
            var input = new ListSpacesInput();
            await _mediator.PublishAsync(input);
            return _presenter.ViewModel;
        }
    }
}
