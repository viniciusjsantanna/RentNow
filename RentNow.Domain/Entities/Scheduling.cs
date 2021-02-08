using RentNow.Domain.ValueObjects;
using System;

namespace RentNow.Domain.Entities
{
    public class Scheduling : BaseEntity<Guid>
    {
        public Client Client { get; set; }
        public Hours TotalHours { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
