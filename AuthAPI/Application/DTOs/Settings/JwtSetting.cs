using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Settings
{
    public class JwtSetting
    {
        public string Secret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpireMinutes { get; set; }
    }
}
