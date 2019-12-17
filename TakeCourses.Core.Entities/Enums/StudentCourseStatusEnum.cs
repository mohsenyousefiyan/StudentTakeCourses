using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TakeCourses.Core.Entities.Enums
{
    public enum StudentCourseStatusEnum
    {
        Draft=1,
        Confirmed=2
    }
    public enum StudentCourseDetailStatusEnum
    {
        Taken= 1,
        Passed=2,
        Failed=3,
        Canceled=4
    }

    public enum EnuResultStatusCode
    {
        [Display(Name = "خطای احراز هویت")]
        UnAuthorized = 1,

        [Display(Name = "پارامتر های ارسالی معتبر نیستند")]
        BadRequest = 2,

        [Display(Name = "یافت نشد")]
        NotFound = 3,

        [Display(Name = "خطایی در پردازش رخ داد")]
        LogicError = 4,

        [Display(Name = "خطایی در سرور رخ داده است")]
        ServerError = 5,

        [Display(Name = "عملیات با موفقیت انجام شد")]
        Success = 6
    }
}
