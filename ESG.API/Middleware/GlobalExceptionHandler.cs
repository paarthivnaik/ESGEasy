﻿using ESG.Application.Exception;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ESG.API.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            System.Exception exception,
            CancellationToken cancellationToken)
        {
            int statusCode = exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };    
            // Create a ProblemDetails object
            var problemDetails = new
            {
                Status = statusCode,
                Title = GetTitleForStatusCode(statusCode),
                Detail = exception.Message,
                Instance = httpContext.Request.Path,
                Exception = exception.InnerException,
                StackTrace = exception.StackTrace
            };

            httpContext.Response.StatusCode = statusCode; //problemDetails.Status.Value;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
        private string GetTitleForStatusCode(int statusCode) => statusCode switch
        {
            StatusCodes.Status400BadRequest => "Bad Request",
            StatusCodes.Status401Unauthorized => "Unauthorized",
            StatusCodes.Status404NotFound => "Not Found",
            _ => "Internal Server Error",
        };
    }

}
