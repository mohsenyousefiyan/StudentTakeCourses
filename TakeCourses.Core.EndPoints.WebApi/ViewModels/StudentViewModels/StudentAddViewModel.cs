using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.EndPoints.WebApi.ViewModels.StudentViewModels
{
    public class StudentAddViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string NationCode { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string FatherName { get; set; }
        public List<Address> Addresses { get; private set; }
        public List<PhoneNumber> PhoneNumbers { get; private set; }
        [Required]
        public string StudentCode { get; set; }
        [Required]
        public Int16 FieldId { get; set; }
        [Required]
        public byte EducationLevelId { get; set; }
        [Required]
        public DateTime EnteringDate { get; set; }
    }
}
