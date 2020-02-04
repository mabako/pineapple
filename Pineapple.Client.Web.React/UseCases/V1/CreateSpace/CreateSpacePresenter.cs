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
                Status = 409,
                Title = "Space already exists",
                Detail = message
            });
        }
    }
}
