using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Dtos.EducationLevelDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Services
{
    public interface IEducationLevelService
    {
        BaseResultModel<EducationLevel> CreateNewEducationLevel(string levelname);
        BaseResultModel<EducationLevel> EditEducationLevel(byte id, string levelname);
        BaseResultModel DeleteEducationLevel(byte id);
        EducationLevel GetEducationById(byte id);
        EducationLevel GetEducationByName(string levelname);
        List<EducationLevel> SearchEducationLevel(EducationLevelSearchDto educationLevel);
    }
}
