using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Services
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
    }
}
