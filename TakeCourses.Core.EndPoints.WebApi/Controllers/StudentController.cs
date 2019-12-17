using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeCourses.Core.Contracts.Services;
using TakeCourses.Core.Entities.Dtos.StudentDto;
using TakeCourses.Core.Entities.Enums;
using TakeCourses.EndPoints.WebApi.ViewModels.BaseViewModels;
using TakeCourses.EndPoints.WebApi.ViewModels.StudentViewModels;

namespace TakeCourses.EndPoints.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetById(Int16 id)
        {
            var Result = studentService.GetStudentById(id);
            return Ok(new BaseApiResultModel(statuscode: EnuResultStatusCode.Success, issuccess: true, result: Result));
        }

        [HttpGet]
        [Route("SearchCourse")]
        public IActionResult SearchCourse([FromQuery]StudentSearchViewModel model)
        {
            var inputmodel = mapper.Map<StudentSearchDto>(model);
            var Result = studentService.SearchStudent(inputmodel);
            return Ok(new BaseApiResultModel(statuscode: EnuResultStatusCode.Success, issuccess: true, result: Result));
        }

        [HttpPost]
        public IActionResult CreateNewStudent(StudentAddViewModel model)
        {
            var inputmodel = mapper.Map<StudentAddDto>(model);
            var Result = studentService.CreateNewStudent(inputmodel);
            return Ok(new BaseApiResultModel(statuscode: Result.StatusCode, issuccess: Result.IsSuccess, message: Result.ErrorMessage, result: Result.Result));
        }

        [HttpPut]
        public IActionResult EditCourse(Int16 id, StudentAddViewModel model)
        {
            var inputmodel = mapper.Map<StudentAddDto>(model);
            var Result = studentService.EditStudent(id, inputmodel);
            return Ok(new BaseApiResultModel(statuscode: Result.StatusCode, issuccess: Result.IsSuccess, message: Result.ErrorMessage, result: Result.Result));
        }

    }
}