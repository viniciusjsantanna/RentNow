using RentNow.Domain.Enum;
using RentNow.Domain.ValueObjects;
using System;

namespace RentNow.Domain.Entities
{
    public class Vehicle : BaseEntity<Guid>
    {
        public Plate Plate { get; set; }
        public Brand CarBrand { get; set; }
        public CarModel CarModel { get; set; }
        public Year Year { get; set; }
        public HourPrice HourPrice { get; set; }
        public FuelType Fuel { get; set; }
        public TrunkLimit TrunkLimit { get; set; }
        public CategoryType Category { get; set; }
    }
}
