using AutoMapper;
using RentNow.Application.CQRS.Vehicles.Commands.Register;
using RentNow.Application.DTOs.Vehicle;
using RentNow.Application.Extensions.Enum;
using RentNow.Domain.Entities;

namespace RentNow.Application.AutoMapper
{
    public class VehicleMapper : Profile
    {
        public VehicleMapper()
        {
            CreateMap<RegisterVehicleCommand, Vehicle>();

            CreateMap<Vehicle, VehicleDTO>()
                .ForMember(e => e.HourPrice, opt => opt.MapFrom(e => e.HourPrice.ToString("N2")))
                .ForMember(e => e.Year, opt => opt.MapFrom(e => e.Year.ToInt()))
                .ForMember(e => e.Fuel, opt => opt.MapFrom(e => e.Fuel.GetDescription()))
                .ForMember(e => e.Category, opt => opt.MapFrom(e => e.Category.GetDescription()));
        }
    }
}
