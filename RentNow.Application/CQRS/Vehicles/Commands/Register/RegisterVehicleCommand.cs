using MediatR;
using RentNow.Application.Interfaces;
using RentNow.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.CQRS.Vehicles.Commands.Register
{
    public class RegisterVehicleCommand : IRequest<IResponse>
    {
        public string Plate { get; set; }
        public int Year { get; set; }
        public Guid CarBandKey { get; set; }
        public Guid CarModelKey { get; set; }
        public FuelType Fuel { get; set; }
        public int TrunkLimit { get; set; }
        public CategoryType Category { get; set; }
        public decimal HourPrice { get; set; }
    }
}
