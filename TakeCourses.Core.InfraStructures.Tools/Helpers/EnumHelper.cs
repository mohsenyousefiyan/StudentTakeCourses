using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeCourses.InfraStructures.Tools.Helpers
{
    public static class EnumHelper
    {
        public static string ToDisplay(this Enum value)
        {
            if (value == null)
                return "";

            var attribute = value.GetType().GetField(value.ToString())
                .GetCustomAttributes(false).FirstOrDefault();

            if (attribute == null)
                return value.ToString();

            var propValue = attribute.GetType().GetProperty("Name").GetValue(attribute);
            return propValue.ToString();
        }
    }
}
