using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Domain.Entities
{
    public class BaseEntity<T>
    {
        public T Key { get; set; }
    }
}
