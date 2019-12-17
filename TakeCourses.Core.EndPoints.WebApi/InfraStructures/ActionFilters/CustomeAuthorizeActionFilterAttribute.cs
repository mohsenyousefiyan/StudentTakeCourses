using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeCourses.Core.Contracts.Services;
using TakeCourses.Core.Entities.Enums;
using TakeCourses.EndPoints.WebApi.ViewModels.BaseViewModels;

namespace TakeCourses.EndPoints.WebApi.InfraStructures.ActionFilters
{
    public class CustomeAuthorizeActionFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IUserService userService;

        public CustomeAuthorizeActionFilterAttribute(IUserService userService)
        {
            this.userService = userService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
                context.Result = new OkObjectResult(new BaseApiResultModel(statuscode: EnuResultStatusCode.UnAuthorized));

            if (!userService.IsUserValid(context.HttpContext.User.Identity.Name))
                context.Result = new OkObjectResult(new BaseApiResultModel(statuscode: EnuResultStatusCode.UnAuthorized));
        }
    }
}
