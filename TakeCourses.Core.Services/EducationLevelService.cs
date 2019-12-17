using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Contracts.Services;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Dtos.EducationLevelDto;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.Core.Services
{
    public class EducationLevelService : IEducationLevelService
    {
        private readonly IEducationLevelQueryRepository queryRepository;
        private readonly IEducationLevelCommandRepository commandRepository;

        public EducationLevelService(IEducationLevelQueryRepository queryRepository, IEducationLevelCommandRepository commandRepository)
        {
            this.queryRepository = queryRepository;
            this.commandRepository = commandRepository;
        }

        public BaseResultModel<EducationLevel> CreateNewEducationLevel(string levelname)
        {
            var addedItem = GetEducationByName(levelname);
            if (addedItem != null)
                return new BaseResultModel<EducationLevel>() { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "عنوان مقطع تحصیلی از قبل به ثبت رسیده است" };

            addedItem=commandRepository.AddEducationLevel(levelname);
            return new BaseResultModel<EducationLevel>() { IsSuccess = true, Result = addedItem };
        }

        public BaseResultModel DeleteEducationLevel(byte id)
        {
            var deleted = GetEducationById(id);
            if (deleted == null)
                return new BaseResultModel() { StatusCode = EnuResultStatusCode.NotFound };

            var Result=commandRepository.DeleteEducationLevel(id);
            if (!Result)
                return new BaseResultModel() { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "به دلیل استفاده در دیگر قسمت ها قادر به حذف نیستید" };

            return new BaseResultModel() { IsSuccess = true };
        }

        public BaseResultModel<EducationLevel> EditEducationLevel(byte id, string levelname)
        {
            if (GetEducationById(id) == null)
                return new BaseResultModel<EducationLevel>() { StatusCode = EnuResultStatusCode.NotFound };

            var editedItem = GetEducationByName(levelname);
            if (editedItem != null)
            {
                if (editedItem.Id != id)
                    return new BaseResultModel<EducationLevel>() { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "عنوان مقطع تحصیلی از قبل به ثبت رسیده است" };
            }
            editedItem = commandRepository.EditEducationLevel(id, levelname);
            return new BaseResultModel<EducationLevel>() { IsSuccess = true, Result = editedItem };
        }

        public EducationLevel GetEducationById(byte id)
        {
            return queryRepository.GetEducationById(id);
        }

        public EducationLevel GetEducationByName(string levelname)
        {
            return queryRepository.GetEducationByName(levelname);
        }

        public List<EducationLevel> SearchEducationLevel(EducationLevelSearchDto educationLevel)
        {
            return queryRepository.SearchEducationLevel(educationLevel);
        }
    }
}
