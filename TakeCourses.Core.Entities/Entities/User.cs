using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.Core.Entities.Entities
{
    public class User:BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationCode { get; set; }
        public DateTime BirthDate { get; set; }
        public string FatherName { get; set; }
        public List<Address> Addresses { get; private set; }
        public List<PhoneNumber> PhoneNumbers { get;private set; }       
        public UserGroup UserGroup { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }        
    }

    public class Address
    {
        public byte AddressTypeId { get; set; }
        public AddressType AddressType { get; set; }
        public string AddressLine { get; set; }
    }

    public class PhoneNumber
    {
        public byte PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; }
        public string Number { get; set; }
    }
}
