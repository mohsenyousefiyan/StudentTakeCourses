using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Entities.Dtos.User;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.InfraStructures.DAL.SQL.Context;

namespace TakeCourses.InfraStructures.DAL.SQL.Repository
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private readonly ApplicationQueryDbContext queryDbContext;

        public UserQueryRepository(ApplicationQueryDbContext queryDbContext)
        {
            this.queryDbContext = queryDbContext;
        }

        public User GetUserById(int id)
        {
            return queryDbContext.Users
                 .AsNoTracking()
                 .Where(x => x.Id == id)
                 .FirstOrDefault();
        }

        public User GetUserByNationCode(string nationcode)
        {
            return queryDbContext.Users
                 .AsNoTracking()
                 .Where(x => x.NationCode == nationcode)
                 .FirstOrDefault();
        }

        public User GetUserByUserName(string UserName)
        {
            return queryDbContext.Users
                .AsNoTracking()
                .Where(x => x.UserName  == UserName)
                .FirstOrDefault();
        }

        public List<User> SearchUser(UserSearchDto userSearch)
        {
            throw new NotImplementedException();
        }
    }
}
