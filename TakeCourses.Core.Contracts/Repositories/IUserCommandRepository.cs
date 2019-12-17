using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Dtos.User;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface IUserCommandRepository
    {
        User AddUser(UserAddDto userdto);
        User EditUser(int id, UserAddDto userdto);
        bool DeleteUser(int id);
    }
}
