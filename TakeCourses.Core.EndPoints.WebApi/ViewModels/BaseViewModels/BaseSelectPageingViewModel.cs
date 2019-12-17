using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TakeCourses.EndPoints.WebApi.ViewModels.BaseViewModels
{
    public class BaseSelectPageingViewModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public Boolean ShowPagingView { get; set; } = false;
    }
}
