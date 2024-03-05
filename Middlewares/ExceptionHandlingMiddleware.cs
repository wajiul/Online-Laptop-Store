using LaptopStoreAPI.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;

namespace LaptopStoreAPI.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(InvalidModelStateException ex)
            {
                await ResponseToExceptionAsync(context, ex.Message, StatusCodes.Status400BadRequest);
            }
            catch(DomainNotFoundException ex)
            {
                await ResponseToExceptionAsync(context, ex.Message, StatusCodes.Status404NotFound);
            }
            catch(DomainExistException ex)
            {
                await ResponseToExceptionAsync(context, ex.Message, StatusCodes.Status400BadRequest);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException is SqlException sqlException)
                {
                    await ResponseToExceptionAsync(context, sqlException.Message, StatusCodes.Status409Conflict);
                }
                await ResponseToExceptionAsync(context, dbUpdateException.Message, StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occured.");
                await ResponseToExceptionAsync(context, "An error occured", StatusCodes.Status500InternalServerError);
            }
        }


        private static async Task ResponseToExceptionAsync(HttpContext context, string message, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(message);
        }

    }
}
