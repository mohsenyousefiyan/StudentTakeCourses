using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Contracts.Services;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserQueryRepository userQueryRepository;

        public UserService(IUserQueryRepository userQueryRepository)
        {
            this.userQueryRepository = userQueryRepository;
        }

        public bool IsUserValid(string username)
        {
            //موقتا چک نمی کنیم
            return true;
        }

        public BaseResultModel<User> UserLogin(string username, string password)
        {
            var user = userQueryRepository.GetUserByUserName(username.ToLower());

            if (user == null)
                return new BaseResultModel<User>() { StatusCode = EnuResultStatusCode.NotFound, ErrorMessage = "نام کاربری یا کلمه عبور نامعتبر است" };

            if (user.Password != password)
                return new BaseResultModel<User>() { StatusCode = EnuResultStatusCode.NotFound, ErrorMessage = "نام کاربری یا کلمه عبور نامعتبر است" };
            

            return new BaseResultModel<User>() { StatusCode = EnuResultStatusCode.Success, IsSuccess = true, Result = user };

        }
    }
}
