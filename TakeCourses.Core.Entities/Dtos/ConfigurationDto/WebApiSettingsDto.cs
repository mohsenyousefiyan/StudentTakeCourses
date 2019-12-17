using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.Core.Entities.Dtos.ConfigurationDto
{
    public class WebApiSettingsDto
    {
        public JwtSettingsDto JwtSettings { get; set; }
    }

    public class JwtSettingsDto
    {
        public string SecretKey { get; set; }
        public string Encryptkey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int NotBeforeMinutes { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
