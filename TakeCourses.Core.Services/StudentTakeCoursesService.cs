using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Contracts.Services;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Dtos.TakeCourseDto;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.Core.Services
{
    public class StudentTakeCoursesService : IStudentTakeCoursesService
    {
        private readonly IStudentCourseQueryRepository studentCourseQueryRepo;
        private readonly IStudentCourseCommandRepository studentcommandRepository;
        private readonly ISyllabusService syllabusService;
        private readonly ITermCourseService termCourseService;

        public StudentTakeCoursesService(IStudentCourseQueryRepository studentCourseQueryRepo, IStudentCourseCommandRepository studentcommandRepository, ISyllabusService syllabusService, ITermCourseService termCourseService)
        {
            this.studentCourseQueryRepo = studentCourseQueryRepo;
            this.studentcommandRepository = studentcommandRepository;
            this.syllabusService = syllabusService;
            this.termCourseService = termCourseService;
        }

       
        public BaseResultModel<List<String>> ProcessStudentTakeCourse(int studentcourseid)
        {
            var studentcourse = studentCourseQueryRepo.GetStudentCourseById(studentcourseid);
            var takecoursedetails = studentCourseQueryRepo.GetStudentCourseDetail(studentcourseid);
            var ErrorList = new List<string>();

            if (takecoursedetails == null || (takecoursedetails != null && takecoursedetails.Count == 0))
                return new BaseResultModel<List<string>> { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "هیچ درسی توسط دانشجو اخذ نشده است" };


            //به دست آوردن چارت درسی دانشجو که بر اساس آن پیش نیاز هم نیاز و ... به دست می آید
            var syllabus = GetStudetentSyllabus(studentcourse.Student);
            if (syllabus == null ||(syllabus!=null && syllabus.Count==0))
                return new BaseResultModel<List<string>>() { StatusCode = EnuResultStatusCode.NotFound, ErrorMessage = "چارت درسی دانشجو یافت نشد" };

            Int16 studentunitpasscount = studentCourseQueryRepo.GetStudentUnitPassedCount(studentcourse.StudentId);

            foreach (var item in takecoursedetails)
            {
                //بررسی تکراری نبودن دانشجو و درس
                if (studentCourseQueryRepo.IsStudentTakeaCourse(studentcourseid, item.TermCourseId))
                    ErrorList.Add($"دانشجو در این ترم یکبار درس {item.TermCourse.Course.CourseName} را اخذ کرده است");

                //بررسی وجود جای خالی
                if (CapacityValdiation(item.TermCourseId, item.TermCourse.Capacity))
                    ErrorList.Add($"ظرفیت درس {item.TermCourse.Course.CourseName} تکمیل شده است");

                //بررسی حداقل تعداد واحد پاس شده
                CheckRequiredPassedCount(syllabus, item.TermCourse.CourseId, studentunitpasscount);

                //بررسی تداخل نداشتن ساعات برگزاری
                //بررسی تداخل نداشتن ساعات امتحان
                //بررسی پیش نیاز و هم نیاز
                //بررسی حداقل واحد مورد نیاز
            }

            if (ErrorList.Count > 0)
                return new BaseResultModel<List<string>>() {StatusCode=EnuResultStatusCode.LogicError, IsSuccess = false, Result = ErrorList };

            return new BaseResultModel<List<string>>() { IsSuccess=true};
        }

        public BaseResultModel<int> StartTakeCourse(StartTakeCourseDto model)
        {            
            //کنترل اینکه رکورد مستر درج شده یا نه    
            var studentcourse = studentCourseQueryRepo.GetStudentCourseByTermId(model.StudentId, model.TermId);
            
            //کنترل اینکه آیا دانشجو برای ترم مشخص شده انتخاب واحد از قبل کرده یانه و  وضعیت آن قطعی است یا پیش نویس
            if (studentcourse != null && studentcourse.RegisterStatus == StudentCourseStatusEnum.Confirmed)
                return new BaseResultModel<int>() { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "انتخاب واحد این ترم دانشجو ثبت قطعی شده و قابل تغییر نیست" };

            var resultid=studentcommandRepository.StartStudentTakeCourse(model);
            return new BaseResultModel<int>() { IsSuccess = true, Result = resultid };
        }

        public BaseResultModel TakeNewCourse(TakeNewCourseDto model)
        {
            //کنترل اینکه درس یکبار ثبت نشده باشد
            if (studentCourseQueryRepo.IsStudentTakeaCourse(model.StudentCourseId, model.TermCourseId))
                return new BaseResultModel() { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "این درس یکبار توسط دانشجو انتخاب شده است" };
           
            studentcommandRepository.TakeNewCourse(model);
            return new BaseResultModel() { IsSuccess = true };
        }

        public bool ConfirmedStudentTakeCourse(int studentcourseid)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// بررسی می کند یک درس ظرفیت برای ثبت نام دارد یا خیر
        /// </summary>        
        private bool CapacityValdiation(int termcourseid,byte capacity)
        {
            var RegisterCount=studentCourseQueryRepo.GetStudentCountOfTakeCourse(termcourseid);
            if(RegisterCount>=capacity)
                return false;

            return true;
        }

        //بررسی حداقل واحد مورد نیاز
        private bool CheckRequiredPassedCount(List<Syllabus> syllabus,Int16 courseid,Int16 studentunitpasscount)
        {           
            var RequiredPassedCount = syllabus.Where(x => x.CourseId == courseid)
                .Select(x => x.RequiredPassedCount)
                .FirstOrDefault();

            if(RequiredPassedCount>0)            
                if (RequiredPassedCount > studentunitpasscount)
                    return false;
            

            return true;
        }
        private List<Syllabus> GetStudetentSyllabus(Student student)
        {
            return syllabusService.GetSyllabusByFieldId(student.FieldId, student.EnteringDate);
        }
    }
}
