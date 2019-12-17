using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeCourses.Core.Entities.Enums;
using TakeCourses.EndPoints.WebApi.ViewModels.BaseViewModels;

namespace TakeCourses.Core.EndPoints.WebApi.InfraStructures.MiddleWares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string message = null;

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                message = ex.Message;
                await WriteToResponseAsync();
            }


            async Task WriteToResponseAsync()
            {
                if (httpContext.Response.HasStarted)
                    throw new InvalidOperationException("The response has already started, the http status code middleware will not be executed.");

                var result = new BaseApiResultModel(statuscode: EnuResultStatusCode.ServerError, message: message);
                var json = JsonConvert.SerializeObject(result);

                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}
