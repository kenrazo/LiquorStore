using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using LiquorStore.Common.Entities;
using LiquorStore.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LiquorStore.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (BaseException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

        }

        private static Task HandleExceptionAsync(HttpContext context, BaseException ex)
        {
            var code = HttpStatusCode.InternalServerError;
            switch (ex)
            {
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    break;
                case ForbiddenException _:
                    code = HttpStatusCode.Forbidden;
                    break;
                case ValidationException _:
                    code = HttpStatusCode.BadRequest;
                    break;
                case UnauthorizedException _:
                    code = HttpStatusCode.Unauthorized;
                    break;
            }

            var result = string.Empty;
            if (!string.IsNullOrEmpty(ex.Message))
            {
                result = JsonConvert.SerializeObject(ex.ErrorResponse);
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var errorReferenceKey = Guid.NewGuid().ToString();
            var result = new ErrorResponse
            { Message = "A unhandled exception has occurred", ReferenceKey = errorReferenceKey };
            var resultString = JsonConvert.SerializeObject(result);

            _logger.LogError(ex, $"A unhandled exception has occurred - {result.ReferenceKey}");
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(resultString);
        }
    }
}
