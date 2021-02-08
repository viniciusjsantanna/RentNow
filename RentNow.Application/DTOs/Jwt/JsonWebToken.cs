using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.DTOs.Jwt
{
    public class JsonWebToken
    {
        public string AccessToken { get; set; }
        public DateTime ExpiresIn { get; set; }

    }
}
