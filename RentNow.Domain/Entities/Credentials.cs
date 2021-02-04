using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.Entities
{
    public class Credentials : BaseEntity<Guid>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
