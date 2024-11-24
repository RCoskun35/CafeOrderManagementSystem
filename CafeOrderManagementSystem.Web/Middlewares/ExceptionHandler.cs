using FluentValidation;

namespace CafeOrderManagementSystem.Web.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger, IHostEnvironment env)
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
            catch (ValidationException ex)
            {
                await HandleValidationExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                await HandleGenericExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 403;
            return context.Response.WriteAsync($@"
            <html>
                <body>
                    <h1>Beklenmeyen Hata</h1>
                    <p>Hata</p>
                    <ul>
                        {string.Join("", exception.Errors.Select(s => s.PropertyName).ToList())}
                    </ul>
                   
                     <a href='/'>Ana Sayfaya Don</a>
                </body>
            </html>");
        }
        private Task HandleGenericExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "text/html";
            context.Response.StatusCode = 500;
            return context.Response.WriteAsync($@"
            <html>
                <body>
                    <h1>Beklenmeyen Hata</h1>
                    <p>Hata</p>
                    <ul>
                        <li>{exception.Message}</li>
                    </ul>
                   
                     <a href='/'>Ana Sayfaya Don</a>
                </body>
            </html>");
        }
    }
}
