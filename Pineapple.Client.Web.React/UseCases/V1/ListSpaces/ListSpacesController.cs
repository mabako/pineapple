using System.Threading.Tasks;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pineapple.Application.Boundaries.ListSpaces;

namespace Pineapple.Client.Web.React.UseCases.V1.ListSpaces
{
    [Route("$/api/[controller]")]
    public class SpacesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ListSpacesPresenter _presenter;

        /// <summary>
        /// Creates a new <see cref="SpacesController"/>.
        /// </summary>
        /// <param name="mediator">mediator</param>
        /// <param name="presenter">presenter</param>
        public SpacesController(IMediator mediator, ListSpacesPresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Lists all spaces.
        /// </summary>
        /// <returns>existing space names</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Index()
        {
            var input = new ListSpacesInput();
            await _mediator.PublishAsync(input);
            return _presenter.ViewModel;
        }
    }
}
