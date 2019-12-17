using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.User;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface IUserQueryRepository
    {
        User GetUserById(int id);
        User GetUserByUserName(string UserName);
        User GetUserByNationCode(string nationcode);
        List<User> SearchUser(UserSearchDto userSearch);        
    }
}
