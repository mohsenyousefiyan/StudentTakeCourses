using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Services
{
    public interface IUserService
    {
        bool IsUserValid(string username);
        BaseResultModel<User> UserLogin(string username, string password);
    }
}
