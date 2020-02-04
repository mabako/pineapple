using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pineapple.Application.Boundaries.CreateSpace;
using Pineapple.Domain.Spaces.ValueObjects;

namespace Pineapple.Client.Web.React.UseCases.V1.CreateSpace
{
    /// <summary>
    /// Space controller.
    /// </summary>
    [Route("$/api/[controller]")]
    public sealed class SpacesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CreateSpacePresenter _presenter;

        public SpacesController(IMediator mediator, CreateSpacePresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Creates a space.
        /// </summary>
        /// <param name="request">request to create a space</param>
        /// <returns>the space name</returns>
        [HttpPut("{SpaceName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateSpaceResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromRoute] [Required] CreateSpaceRequest request)
        {
            var input = new CreateSpaceInput(new SpaceName(request.SpaceName));
            await _mediator.PublishAsync(input);
            return _presenter.ViewModel;
        }
    }
}
