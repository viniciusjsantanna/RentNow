using RentNow.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.Entities
{
    public class Brand : BaseEntity<Guid>
    {
        public Name Name { get; set; }
    }
}
