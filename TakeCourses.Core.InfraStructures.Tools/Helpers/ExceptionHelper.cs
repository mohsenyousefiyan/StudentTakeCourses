using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.InfraStructures.Tools.Helpers
{
    public static class ExceptionHelper
    {
        public static string GetErrorMessage(this Exception exception)
        {
            if (exception != null && exception.InnerException != null)
                return GetErrorMessage(exception.InnerException);

            return exception.Message;
        }

        
    }
}
