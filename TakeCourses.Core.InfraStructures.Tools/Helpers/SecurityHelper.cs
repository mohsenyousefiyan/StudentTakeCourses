using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TakeCourses.InfraStructures.Tools.Helpers
{
    public class SecurityHelper
    {
        public static String SHA256_Hash(String value)
        {
            try
            {
                using (SHA256 hash = SHA256Managed.Create())
                {
                    return String.Concat(hash
                      .ComputeHash(Encoding.UTF8.GetBytes(value))
                      .Select(item => item.ToString("x2")));
                }
            }
            catch
            {
                return "";
            }
        }
    }
}
