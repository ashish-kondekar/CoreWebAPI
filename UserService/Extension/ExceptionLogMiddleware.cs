using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using User.Core;
using User.Core.DTOs;

namespace User.Api.Extension
{
    public class ExceptionLogMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;

            switch (exception.GetType().Name)
            {
                case nameof(BadHttpRequestException):
                case nameof(ArgumentException):
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case nameof(BusinessException):
                    statusCode = HttpStatusCode.UnprocessableEntity;
                    break;
                case nameof(NotImplementedException):
                    statusCode = HttpStatusCode.NotImplemented;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            /* Log actual exception here and
             * Send the user understandable message
             * e.g. log.Info(exception) or log.Info(exception.Message)
             */
            context.Response.ContentType = "application/json";
            var res = JsonSerializer.Serialize(
                new ExceptionDetailsDTO
                {
                    Message = Constants.ServerErrorMessage,
                    StatusCode = (int)statusCode
                });
            await context.Response.WriteAsync(res);
            return;
        }
    }
}
