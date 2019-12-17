using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.EmploymentTypeDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface IEmploymentTypeQueryRepository
    {
        EmploymentType GetEmploymentTypeById(byte id);
        EmploymentType GetEmploymentTypeByName(string name);
        List<EmploymentType> SearchEmploymentType(EmploymentTypeSearchDto employmentType);
    }
}
