using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.EndPoints.WebApi.ViewModels.UserViewModels
{
    public class UserLoginResultViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationCode { get; set; }       
        public UserGroup UserGroup { get; set; }                     
    }
}
