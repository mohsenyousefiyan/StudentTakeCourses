using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeCourses.Core.Contracts.Services;
using TakeCourses.Core.Entities.Dtos.EducationLevelDto;
using TakeCourses.Core.Entities.Enums;
using TakeCourses.EndPoints.WebApi.InfraStructures.ActionFilters;
using TakeCourses.EndPoints.WebApi.ViewModels.BaseViewModels;
using TakeCourses.EndPoints.WebApi.ViewModels.EducationLevelViewModels;

namespace TakeCourses.EndPoints.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(CustomeAuthorizeActionFilterAttribute))]
    public class EducationLevelController : ControllerBase
    {
        private readonly IEducationLevelService educationLevelService;
        private readonly IMapper mapper;

        public EducationLevelController(IEducationLevelService educationLevelService, IMapper mapper)
        {
            this.educationLevelService = educationLevelService;
            this.mapper = mapper;
        }

        [HttpGet]                
        public  IActionResult GetById(byte id)
        {
            var Result = educationLevelService.GetEducationById(id);
            return Ok(new BaseApiResultModel(statuscode: EnuResultStatusCode.Success, issuccess: true, result: Result));
        }

        [HttpGet]
        [Route("SearchEducation")]
        public IActionResult SearchEducation([FromQuery]EducationLevelSearchViewModel educationLevel)
        {
            var inputmodel = mapper.Map<EducationLevelSearchDto>(educationLevel);
            var Result = educationLevelService.SearchEducationLevel(inputmodel);
            return Ok(new BaseApiResultModel(statuscode: EnuResultStatusCode.Success, issuccess: true, result: Result));
        }

        [HttpPost]
        public IActionResult CreateNewEducationLevel(EducationLevelAddViewMoel model)
        {
            var Result = educationLevelService.CreateNewEducationLevel(model.LevelName);
            return Ok(new BaseApiResultModel(statuscode: Result.StatusCode, issuccess: Result.IsSuccess,message:Result.ErrorMessage, result: Result.Result));
        }

        [HttpPut]
        public IActionResult EditEducationLevel(byte id,EducationLevelAddViewMoel model)
        {
            var Result = educationLevelService.EditEducationLevel(id, model.LevelName);
            return Ok(new BaseApiResultModel(statuscode: Result.StatusCode, issuccess: Result.IsSuccess, message: Result.ErrorMessage, result: Result.Result));
        }

        [HttpDelete]
        public IActionResult DeleteEducationLevel(byte id)
        {
            var Result = educationLevelService.DeleteEducationLevel(id);
            return Ok(new BaseApiResultModel(statuscode: Result.StatusCode, issuccess: Result.IsSuccess, message: Result.ErrorMessage));
        }
    }
}