using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TakeCourses.Core.Contracts.Services;
using TakeCourses.Core.Entities.Enums;
using TakeCourses.EndPoints.WebApi.ViewModels.BaseViewModels;
using TakeCourses.EndPoints.WebApi.ViewModels.UserViewModels;
using TakeCourses.InfraStructures.Tools.Helpers;

namespace TakeCourses.EndPoints.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public UserController(IUserService userService,ITokenService tokenService,IMapper mapper)
        {
            this.userService = userService;
            this.tokenService = tokenService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> UserLoginAsync(UserLoginViewModel model)
        {
            var user =  userService.UserLogin(model.UserName, SecurityHelper.SHA256_Hash(model.Password));
            if (user.IsSuccess && user.Result != null && user.Result.IsActive)
            {
                var jwttoken = await tokenService.GenerateToken(user.Result);
                var useinfo = mapper.Map<UserLoginResultViewModel>(user.Result);
                var usertoken = new {UserInfo=useinfo, Token = jwttoken };
                return Ok(new BaseApiResultModel(issuccess: true, statuscode: EnuResultStatusCode.Success, result: usertoken));
            }

            return Ok(new BaseApiResultModel(statuscode: EnuResultStatusCode.NotFound, message: user.ErrorMessage));
        }
    }
}
