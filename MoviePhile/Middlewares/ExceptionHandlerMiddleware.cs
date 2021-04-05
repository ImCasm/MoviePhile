﻿using Domain.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiNetCore.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ExceptionHandler ex)
            {
                await ExceptionHandlerAsync(httpContext, ex, _logger);
            }
        }

        private async Task ExceptionHandlerAsync(HttpContext httpContext, Exception ex, ILogger<ExceptionHandlerMiddleware> logger)
        {
            object errors = null;

            switch (ex)
            {
                case ExceptionHandler e:
                    logger.LogError(ex, "Error Handler");
                    errors = e.Errors;
                    httpContext.Response.StatusCode = (int)e.Code;
                    break;
                case Exception e:
                    logger.LogError(ex, "Error de servidor");
                    errors = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            httpContext.Response.ContentType = "application/json";

            if (errors != null)
            {
                var result = JsonSerializer.Serialize(new { errors });
                await httpContext.Response.WriteAsync(result);
            }
        }

    }

}
