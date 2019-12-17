using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeCourses.Core.Entities.Enums;
using TakeCourses.EndPoints.WebApi.ViewModels.BaseViewModels;

namespace TakeCourses.EndPoints.WebApi.InfraStructures.ActionFilters
{
    public class CustomFlatApiResultActionFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is BadRequestResult badRequestResult)
            {
                var apiResult = new BaseApiResultModel(statuscode: EnuResultStatusCode.BadRequest);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is BadRequestObjectResult badRequestObjectResult)
            {
                var resultobject = badRequestObjectResult.Value;
                string message = "مقادیر ورودی نامعتبر است";

                try
                {
                    if (resultobject is ValidationProblemDetails problemDetails)
                    {
                        var errorMessages = problemDetails.Errors.SelectMany(p => (string[])p.Value).Distinct();
                        message = string.Join(" | ", errorMessages);
                    }
                }
                catch
                {
                }

                var apiResult = new BaseApiResultModel(statuscode: EnuResultStatusCode.BadRequest, message: message);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is UnauthorizedResult unauthorizedResult)
            {
                var apiResult = new BaseApiResultModel(statuscode: EnuResultStatusCode.BadRequest);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is NotFoundResult notFoundResult)
            {
                var apiResult = new BaseApiResultModel(statuscode: EnuResultStatusCode.NotFound);
                context.Result = new JsonResult(apiResult);
            }
            else if (context.Result is NotFoundObjectResult notFoundObjectResult)
            {
                var apiResult = new BaseApiResultModel(statuscode: EnuResultStatusCode.NotFound, result: notFoundObjectResult.Value);
                context.Result = new JsonResult(apiResult);
            }

            base.OnResultExecuting(context);
        }
    }
}
