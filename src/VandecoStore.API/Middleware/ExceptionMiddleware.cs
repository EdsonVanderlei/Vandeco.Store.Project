using System.Net;

namespace VandecoStore.API.Middleware
{
    public class ExceptionMiddleware
    {
        readonly RequestDelegate _next;
        readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                var statusCodeResponse = HttpStatusCode.InternalServerError;
                var problemDetails = BuildProblemDetails(context.Request.Path, ex.Message, statusCodeResponse);
                await HandleErrorResponseAsync(context, (int)statusCodeResponse, problemDetails);
            }
        }

        private static async Task HandleErrorResponseAsync(HttpContext context, int statusCodeResponse, ProblemDetails problemDetails)
        {
            context.Response.StatusCode = statusCodeResponse;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }

        private static ProblemDetails BuildProblemDetails(string instance, string detail, HttpStatusCode statusCodeResponse)
        {
            return new ProblemDetails
            {
                Detail = detail,
                Instance = instance,
                Status = (int)statusCodeResponse,
                Title = statusCodeResponse.ToString(),
                Type = "about:blank",
            };
        }
    }
}
