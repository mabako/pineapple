using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pineapple.Application.Boundaries.CreatePage;
using Pineapple.Domain.Pages.ValueObjects;
using Pineapple.Domain.Spaces.ValueObjects;
using Swashbuckle.AspNetCore.Annotations;

namespace Pineapple.Client.Web.React.UseCases.V1.CreatePage
{

    /// <summary>
    /// Controller to create new pages.
    /// </summary>
    [Route("$/api/v1/pages")]
    [Produces("application/json")]
    [ApiController]
    public class CreatePageController
    {
        private readonly IMediator _mediator;
        private readonly CreatePagePresenter _presenter;

        public CreatePageController(IMediator mediator, CreatePagePresenter presenter)
        {
            _mediator = mediator;
            _presenter = presenter;
        }

        /// <summary>
        /// Creates a new page.
        /// </summary>
        /// <param name="spaceName">Name of the parent space to create this page in.</param>
        /// <param name="pageName">Name of the page to create.</param>
        /// <param name="request">request</param>
        /// <returns>details of the new page</returns>
        [SwaggerOperation(Tags = new []{ "Pages"})]
        [HttpPut("{SpaceName}/{PageName}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreatePageResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult?> Create(
            [FromRoute, Required(AllowEmptyStrings = false)] string spaceName,
            [FromRoute, Required(AllowEmptyStrings = false)] string pageName,
            [FromBody, Required] CreatePageRequest request)
        {
            var input = new CreatePageInput(new SpaceName(spaceName), new PageName(pageName), request.Content);
            await _mediator.PublishAsync(input);
            return _presenter.ViewModel;
        }
    }
}
