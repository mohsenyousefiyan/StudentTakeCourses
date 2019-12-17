using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeCourses.Core.Entities.Enums;
using TakeCourses.InfraStructures.Tools.Helpers;


namespace TakeCourses.EndPoints.WebApi.ViewModels.BaseViewModels
{
    public class BaseApiResultModel
    {
        public bool IsSuccess { get; set; }
        public EnuResultStatusCode StatusCode { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Result { get; set; }

        public BaseApiResultModel(EnuResultStatusCode statuscode, bool issuccess = false, string message = null, object result = null)
        {
            this.IsSuccess = issuccess;
            this.Result = result;
            this.StatusCode =issuccess? EnuResultStatusCode.Success: statuscode;
            this.ErrorMessage = message ?? this.StatusCode.ToDisplay();
        }
    }
}
