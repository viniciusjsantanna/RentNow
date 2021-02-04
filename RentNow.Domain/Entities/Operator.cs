using RentNow.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.Entities
{
    public class Operator : User
    {
        public Registration Registration { get; set; }
    }
}
