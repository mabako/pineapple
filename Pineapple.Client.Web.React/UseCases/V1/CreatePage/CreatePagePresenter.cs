﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pineapple.Application.Boundaries.CreatePage;

namespace Pineapple.Client.Web.React.UseCases.V1.CreatePage
{
    /// <summary>
    /// Maps output values to HTTP responses.
    /// </summary>
    public sealed class CreatePagePresenter : IOutputPort
    {
        /// <summary>
        /// Gets the view model to render as result.
        /// </summary>
        public IActionResult? ViewModel { get; private set; }

        /// <inheritdoc/>
        public void Standard(CreatePageOutput output)
        {
            ViewModel = new OkObjectResult(new CreatePageResponse(output.Page.Space.ToString(), output.Page.Name.ToString()));
        }

        /// <inheritdoc/>
        public void SpaceNotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Space not found",
                Detail = message,
            });
        }

        /// <inheritdoc/>
        public void PageAlreadyExists(string message)
        {
            ViewModel = new ConflictObjectResult(new ProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Title = "Page already exists",
                Detail = message,
            });
        }

        /// <inheritdoc/>
        public void UnableToCreatePage(string message)
        {
            ViewModel = new UnprocessableEntityObjectResult(new ProblemDetails
            {
                Status = StatusCodes.Status422UnprocessableEntity,
                Title = "Unable to create page",
                Detail = message,
            });
        }
    }
}
