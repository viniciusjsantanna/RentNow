using RentNow.Domain.Enum;
using RentNow.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.Entities
{
    public abstract class User : BaseEntity<Guid>
    {
        public Name Name { get; set; }
        public Role Role { get; set; }
        public Credentials Credentials { get; set; }
    }
}
