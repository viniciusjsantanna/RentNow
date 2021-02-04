using RentNow.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.Entities
{
    public class Client : User
    {
        public Cpf Cpf { get; set; }
        public DateTime Birthdate { get; set; }
        public Address Address { get; set; }
    }
}
