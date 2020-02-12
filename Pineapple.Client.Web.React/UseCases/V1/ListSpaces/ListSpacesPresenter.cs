using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pineapple.Application.Boundaries.ListSpaces;

namespace Pineapple.Client.Web.React.UseCases.V1.ListSpaces
{
    /// <summary>
    /// Maps the space collection to a HTTP response.
    /// </summary>
    public sealed class ListSpacesPresenter : IOutputPort
    {
        /// <summary>
        /// Gets the view model to render as result.
        /// </summary>
        public IActionResult? ViewModel { get; private set; }

        /// <inheritdoc/>
        public void Standard(ListSpacesOutput output)
        {
            var response = new ListSpacesResponse(output.ExistingSpaces.GetSpaceNames().Select(x => x.ToString()).ToList());
            ViewModel = new OkObjectResult(response);
        }
    }
}
