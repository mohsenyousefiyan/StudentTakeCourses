using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Entities.Dtos.StudentDto
{
    public class StudentAddDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationCode { get; set; }
        public DateTime BirthDate { get; set; }
        public string FatherName { get; set; }
        public List<Address> Addresses { get; private set; }
        public List<PhoneNumber> PhoneNumbers { get; private set; }
        public string StudentCode { get; set; }
        public Int16 FieldId { get; set; }       
        public byte EducationLevelId { get; set; }      
        public DateTime EnteringDate { get; set; }
    }
}
