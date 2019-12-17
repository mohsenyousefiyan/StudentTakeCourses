using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface IEmploymentTypeCommandRepository
    {
        EmploymentType AddEmploymentType(string employmenttypename);
        EmploymentType EditEmploymentType(byte id,string employmenttypename);
        bool DeleteEmploymentType(byte id);
    }
}
