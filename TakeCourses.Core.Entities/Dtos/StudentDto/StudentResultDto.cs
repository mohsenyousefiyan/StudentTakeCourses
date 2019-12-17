using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Entities.Dtos.StudentDto
{
   public class StudentResultDto
    {
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public Int16 FieldId { get; set; }
        public Field Field { get; set; }
        public byte EducationLevelId { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public DateTime EnteringDate { get; set; }
        public DateTime? GraduationDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationCode { get; set; }
        public DateTime BirthDate { get; set; }
        public string FatherName { get; set; }
        public List<Address> Addresses { get;  set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }

    }
}
