using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pineapple.Domain;

namespace Pineapple.React.Filters
{
    /// <summary>
    /// Filters all exceptions to automatically convert failures into HTTP 400 responses, such as when a value object
    /// simply cannot be created.
    /// </summary>
    public sealed class DomainExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!(context.Exception is DomainException))
                return;

            context.Result = new BadRequestObjectResult(new ProblemDetails
            {
                Status = 400,
                Title = "Bad Request",
                Detail = context.Exception.Message,
            });
            context.ExceptionHandled = true;
        }
    }
}
