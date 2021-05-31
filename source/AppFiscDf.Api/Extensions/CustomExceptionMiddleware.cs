using AppFiscDf.Api.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AppFiscDf.Api.Extensions
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (HttpStatusCodeException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception exceptionObj)
            {
                await HandleExceptionAsync(context, exceptionObj);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, HttpStatusCodeException exception)
        {
            context.Response.ContentType = "application/json";
            string result;
            if (exception != null)
            {
                result = new ErrorDetails() { Message = exception.Message, StatusCode = exception.StatusCode }.ToString();
                context.Response.StatusCode = (int)exception.StatusCode;
            }
            else
            {
                result = new ErrorDetails() { Message = "Runtime Error", StatusCode = HttpStatusCode.BadRequest }.ToString();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            return context.Response.WriteAsync(result);
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var result = new ErrorDetails() { StatusCode = statusCode, Message = exception.Message };

            return context.Response.WriteAsync(result.ToString());
        }
    }
}