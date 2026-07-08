using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CursosAPI.Exceptions.Handlers
{
    public class NaoAutenticadoExceptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not NaoAutenticadoException)
            {
                return ValueTask.FromResult(false);
            }

            ProblemDetails problemDetails = new ProblemDetails
            {
                Title = "Sem autorização, este usuário não está autorizado!",
                Status = StatusCodes.Status401Unauthorized,
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;
            httpContext.Response.WriteAsJsonAsync(problemDetails);
            return ValueTask.FromResult(true);
        }
    }
}
