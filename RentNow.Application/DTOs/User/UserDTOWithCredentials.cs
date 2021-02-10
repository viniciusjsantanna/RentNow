using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.DTOs.User
{
    public class UserDTOWithCredentials
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }
    }
}
