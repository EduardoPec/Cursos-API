using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CursosAPI.Exceptions.Handlers
{
    public class DuplicatedExceptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not DuplicatedException)
            {
                return ValueTask.FromResult(false);
            }

            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = "Conflito, recurso duplicado!",
                Status = StatusCodes.Status409Conflict,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;
            httpContext.Response.WriteAsJsonAsync(problemDetails);
            return ValueTask.FromResult(true);
        }
    }
}
