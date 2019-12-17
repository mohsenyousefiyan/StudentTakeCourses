using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.Core.Entities.Dtos.User
{
    public class UserSearchDto: BaseSelectPageingDto
    {
        public string FullName { get; set; }
        public string NationCode { get; set; }
        public UserGroup? UserGroup { get; set; }
    }
}
