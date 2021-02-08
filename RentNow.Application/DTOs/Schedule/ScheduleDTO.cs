using RentNow.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.DTOs.Schedule
{
    public class ScheduleDTO
    {
        public Guid Key { get; set; }
        public string ClientName { get; set; }
        public string Cpf { get; set; }
        public int TotalHours { get; set; }
        public string VehicleFullName { get; set; }
        public string TotalPrice { get; set; }
        public decimal HourPrice { get; set; }
        public CategoryType Category { get; set; }
    }
}
