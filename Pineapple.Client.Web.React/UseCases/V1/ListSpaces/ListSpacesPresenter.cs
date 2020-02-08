using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pineapple.Application.Boundaries.ListSpaces;

namespace Pineapple.Client.Web.React.UseCases.V1.ListSpaces
{
    public sealed class ListSpacesPresenter : IOutputPort
    {
        public IActionResult? ViewModel { get; private set; }

        public void Standard(ListSpacesOutput output)
        {
            var response = new ListSpacesResponse(output.ExistingSpaces.GetSpaceNames().Select(x => x.ToString()).ToList());
            ViewModel = new OkObjectResult(response);
        }
    }
}
