using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pineapple.Application.Boundaries.CreateSpace;
using Pineapple.Domain.Spaces.ValueObjects;
using Swashbuckle.AspNetCore.Annotations;

namespace Pineapple.Client.Web.React.UseCases.V1.CreateSpace
{
    /// <summary>
    /// Space controller.
    /// </summary>
    [Route("$/api/v1/spaces")]
    [Produces("application/json")]
    [ApiController]
    public sealed class CreateSpaceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CreateSpacePresenter _presenter;

        public CreateSpaceController(IMediator mediator, CreateSpacePresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Creates a space.
        /// </summary>
        /// <param name="request">request to create a space</param>
        /// <returns>the space name</returns>
        [SwaggerOperation(Tags = new[] { "Spaces" })]
        [HttpPut("{SpaceName}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateSpaceResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult?> Create([FromRoute] [Required] CreateSpaceRequest request)
        {
            var input = new CreateSpaceInput(new SpaceName(request.SpaceName!));
            await _mediator.PublishAsync(input);
            return _presenter.ViewModel;
        }
    }
}
