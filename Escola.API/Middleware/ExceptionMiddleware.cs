using Escola.API.Errors;
using Escola.Application.Exceptions;
using System.Text.Json;

namespace Escola.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);                

                await HandleExceptionAsync(httpContext, ex, _env);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, IHostEnvironment env)
        {
            int statusCode = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                BadRequestException => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var response = env.IsDevelopment()
            ? new ApiException(statusCode.ToString(), exception.Message, exception.StackTrace?.ToString()) :
                new ApiException(statusCode.ToString(), exception.Message, string.Empty);

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(response, options);

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }   
    }
}
