using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.Core.Entities.Dtos.User
{
    public class UserAddDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationCode { get; set; }
        public DateTime BirthDate { get; set; }
        public string FatherName { get; set; }
        public List<Address> Addresses { get; private set; }
        public List<PhoneNumber> PhoneNumbers { get; private set; }
        public UserGroup UserGroup { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
