using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pineapple.Application.Boundaries.CreateSpace;

namespace Pineapple.Client.Web.React.UseCases.V1.CreateSpace
{
    /// <summary>
    /// Maps space creation output to HTTP values.
    /// </summary>
    public sealed class CreateSpacePresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Standard(CreateSpaceOutput output) => ViewModel = new OkObjectResult(new CreateSpaceResponse(output.Space.Name.ToString()));

        public void SpaceAlreadyExists(string message)
        {
            ViewModel = new ConflictObjectResult(new ProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Title = "Space already exists",
                Detail = message
            });
        }

        public void UnableToCreateSpace(string message)
        {
            ViewModel = new UnprocessableEntityObjectResult(new ProblemDetails
            {
                Status = StatusCodes.Status422UnprocessableEntity,
                Title = "Unable to create space",
                Detail = message
            });
        }
    }
}
