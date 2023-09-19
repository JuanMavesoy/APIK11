using APIK11.Models;
using Aplicacion.Exceptions;
using System.Net;
using System.Text;
using System.Text.Json;

namespace APIK11.Middleware
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
       
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case AppException e:
                        var response = httpContext.Response;
                        response.ContentType = "application/json";
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var result = JsonSerializer.Serialize(new { message = ex?.Message });
                        await response.WriteAsync(result);
                        break;
                    default:
                        await HandleExceptionAsync(httpContext, ex);
                        break;
                }   
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"Ha ocurrido la siguiente excepcion en el servidor: {exception.Message} en {exception.Source}"
            }.ToString());
        }
    }


}
