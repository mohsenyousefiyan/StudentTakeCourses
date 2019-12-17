using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Contracts.Services;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Dtos.CourseDto;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseQueryRepository queryRepository;
        private readonly ICourseCommandRepository commandRepository;

        public CourseService(ICourseQueryRepository queryRepository,ICourseCommandRepository commandRepository)
        {
            this.queryRepository = queryRepository;
            this.commandRepository = commandRepository;
        }

        public BaseResultModel<Course> CreateNewCourse(CourseAddDto model)
        {
            var addedItem = GetCourseByName(model.FieldId, model.CourseName);
            if (addedItem != null)
                return new BaseResultModel<Course>() { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "عنوان درس از قبل به ثبت رسیده است" };

            addedItem = GetCourseByCode(model.CourseCode);
            if (addedItem != null)
                return new BaseResultModel<Course>() { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "کد درس از قبل به ثبت رسیده است" };

            addedItem = commandRepository.AddCourse(model);
            return new BaseResultModel<Course>() { IsSuccess = true, Result = addedItem };
        }

        public BaseResultModel DeleteCourse(Int16 id)
        {
            var deleted = GetCourseById(id);
            if (deleted == null)
                return new BaseResultModel() { StatusCode = EnuResultStatusCode.NotFound };

            var Result = commandRepository.DeleteCourse(id);
            if (!Result)
                return new BaseResultModel() { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "به دلیل استفاده در دیگر قسمت ها قادر به حذف نیستید" };

            return new BaseResultModel() { IsSuccess = true };
        }

        public BaseResultModel<Course> EditCourse(short id, CourseAddDto model)
        {
            if (GetCourseById(id) == null)
                return new BaseResultModel<Course>() { StatusCode = EnuResultStatusCode.NotFound };

            var editedItem = GetCourseByName(model.FieldId,model.CourseName);
            if (editedItem != null)       
                if (editedItem.Id != id)
                    return new BaseResultModel<Course>() { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "عنوان درس از قبل به ثبت رسیده است" };

            editedItem = GetCourseByCode(model.CourseCode);
            if (editedItem != null)
                if (editedItem.Id != id)
                    return new BaseResultModel<Course>() { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "کد درس از قبل به ثبت رسیده است" };


            editedItem = commandRepository.EditCourse(id, model);
            return new BaseResultModel<Course>() { IsSuccess = true, Result = editedItem };
        }

        public Course GetCourseByCode(string coursecode)
        {
            return queryRepository.GetCourseByCode(coursecode);
        }

        public Course GetCourseById(Int16 id)
        {
            return queryRepository.GetCourseById(id);
        }

        public Course GetCourseByName(Int16 fieldid, string coursename)
        {
            return queryRepository.GetCourseByName(fieldid,coursename);
        }

        public List<Course> GetFieldCourseList(short fieldid)
        {
            return queryRepository.GetFieldCourseList(fieldid);
        }

        public List<Course> SearchCourse(CourseSearchDto model)
        {
            return queryRepository.SearchCourse(model);
        }
    }
}
