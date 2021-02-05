using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.DTOs.CarModel
{
    public class CarModelDTO
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
    }
}
