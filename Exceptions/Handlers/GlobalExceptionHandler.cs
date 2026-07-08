using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CursosAPI.Exceptions.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = "Erro interno no servidor!",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;
            httpContext.Response.WriteAsJsonAsync(problemDetails);
            return ValueTask.FromResult(true);
        }
    }
}
