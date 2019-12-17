using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface IEducationLevelCommandRepository
    {
        EducationLevel AddEducationLevel(string levelname);
        EducationLevel EditEducationLevel(byte id,string levelname);
        bool  DeleteEducationLevel(byte id);
    }
}
