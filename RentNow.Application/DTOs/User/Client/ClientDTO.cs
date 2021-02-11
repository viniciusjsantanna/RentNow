using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.DTOs.User.Client
{
    public class ClientDTO
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
    }
}
