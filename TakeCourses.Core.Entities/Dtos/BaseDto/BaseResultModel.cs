using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.Core.Entities.Dtos.BaseDto
{
    public class BaseResultModel
    {
        public bool IsSuccess { get; set; }
        public EnuResultStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class BaseResultModel<TData> : BaseResultModel
    {
        public TData Result { get; set; }
    }
}
