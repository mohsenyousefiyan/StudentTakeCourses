using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeCourses.Core.Contracts.Services;
using TakeCourses.Core.Entities.Dtos.CourseDto;
using TakeCourses.Core.Entities.Enums;
using TakeCourses.EndPoints.WebApi.ViewModels.BaseViewModels;
using TakeCourses.EndPoints.WebApi.ViewModels.CourseViewModel;

namespace TakeCourses.EndPoints.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;
        private readonly IMapper mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            this.courseService = courseService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetById(Int16 id)
        {
            var Result = courseService.GetCourseById(id);
            return Ok(new BaseApiResultModel(statuscode: EnuResultStatusCode.Success, issuccess: true, result: Result));
        }

        [HttpGet]
        [Route("SearchCourse")]
        public IActionResult SearchCourse([FromQuery]CourseSearchViewModel model)
        {
            var inputmodel = mapper.Map<CourseSearchDto>(model);
            var Result = courseService.SearchCourse(inputmodel);
            return Ok(new BaseApiResultModel(statuscode: EnuResultStatusCode.Success, issuccess: true, result: Result));
        }

        [HttpGet]
        [Route("GetCoursesOfField")]
        public IActionResult CourseList(Int16 fieldid)
        {
            var Result = courseService.GetFieldCourseList(fieldid);
            return Ok(new BaseApiResultModel(statuscode: EnuResultStatusCode.Success, issuccess: true, result: Result));
        }

        [HttpPost]
        public IActionResult CreateNewCourse(CourseAddViewModel model)
        {
            var inputmodel = mapper.Map<CourseAddDto>(model);
            var Result = courseService.CreateNewCourse(inputmodel);
            return Ok(new BaseApiResultModel(statuscode: Result.StatusCode, issuccess: Result.IsSuccess, message: Result.ErrorMessage, result: Result.Result));
        }

        [HttpPut]
        public IActionResult EditCourse(Int16 id, CourseAddViewModel model)
        {
            var inputmodel = mapper.Map<CourseAddDto>(model);
            var Result = courseService.EditCourse(id,inputmodel);
            return Ok(new BaseApiResultModel(statuscode: Result.StatusCode, issuccess: Result.IsSuccess, message: Result.ErrorMessage, result: Result.Result));
        }

        [HttpDelete]
        public IActionResult DeleteEducationLevel(Int16 id)
        {
            var Result = courseService.DeleteCourse(id);
            return Ok(new BaseApiResultModel(statuscode: Result.StatusCode, issuccess: Result.IsSuccess, message: Result.ErrorMessage));
        }

    }
}