using DepositoHelados.Application.Exceptions;
using DepositoHelados.Application.Responses;
using DepositoHelados.Converters;
using System.Net;

namespace DepositoHelados.Middlewares;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var result = new JsonErrorResponse(statusCode);

            switch (ex)
            {
                //    case WarningAppException warningException:
                //        result.StatusCode = (int)HttpStatusCode.InternalServerError;
                //        result.Message = ex.Message;
                //        break;
                //case HttpRequestException httpRequestException:
                //    result.StatusCode = (int)HttpStatusCode.InternalServerError;
                //    result.Message = $"{ex.Message} || {ex?.InnerException?.Message}";
                //    break;
                case ValidatorException validatorException:
                    result.StatusCode = (int)HttpStatusCode.BadRequest;
                    result.Message = ex.Message;
                    break;
                case Exception exception:
                    result.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result.Message = $"{ex.Message}";
                    break;
                default:
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = result.StatusCode;

            await context.Response.WriteAsync(await result.SerializeContent().ReadAsStringAsync());
        }
    }
}