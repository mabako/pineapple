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

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSpaceController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator instance to publish messages with.</param>
        /// <param name="presenter">Presenter for the use case.</param>
        public CreateSpaceController(IMediator mediator, CreateSpacePresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Creates a new space.
        /// </summary>
        /// <param name="request">The request to create a new space.</param>
        /// <returns>Details of the newly created space.</returns>
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
