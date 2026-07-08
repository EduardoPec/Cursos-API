using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CursosAPI.Exceptions.Handlers
{
    public class NotFoundExceptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not NotFoundException)
            {
                return ValueTask.FromResult(false);
            }

            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = "Recurso não encontrado!",
                Status = StatusCodes.Status404NotFound,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;
            httpContext.Response.WriteAsJsonAsync(problemDetails);
            return ValueTask.FromResult(true);
        }
    }
}
