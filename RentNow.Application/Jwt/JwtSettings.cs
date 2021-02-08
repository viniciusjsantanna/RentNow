using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.Jwt
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int ExpirationInMinutes { get; set; }
        public string[] Audience { get; set; }
    }
}
