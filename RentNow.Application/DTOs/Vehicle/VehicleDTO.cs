using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.DTOs.Vehicle
{
    public class VehicleDTO
    {
        public string Plate { get; set; }
        public string CarBrandName { get; set; }
        public string CarModelName { get; set; }
        public int Year { get; set; }
        public string HourPrice { get; set; }
        public string Fuel { get; set; }
        public string Category { get; set; }
        public string TrunkLimit { get; set; }
    }
}
