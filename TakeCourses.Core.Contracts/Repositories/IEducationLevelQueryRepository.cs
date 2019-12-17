using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.EducationLevelDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface IEducationLevelQueryRepository
    {
        EducationLevel GetEducationById(byte id);
        EducationLevel GetEducationByName(string levelname);
        List<EducationLevel> SearchEducationLevel(EducationLevelSearchDto educationLevel);
    }
}
