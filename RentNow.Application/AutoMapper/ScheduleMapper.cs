using AutoMapper;
using RentNow.Application.CQRS.Schedules.Commands.Register;
using RentNow.Application.DTOs.Schedule;
using RentNow.Application.Extensions.Enum;
using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.AutoMapper
{
    public class ScheduleMapper : Profile
    {
        public ScheduleMapper()
        {
            CreateMap<RegisterScheduleCommand, Scheduling>()
                .ForMember(e => e.TotalHours, opt => opt.MapFrom(e => e.TotalHours))
                .ForAllOtherMembers(e => e.Ignore());

            CreateMap<Scheduling, ScheduleDTO>()
                .ForMember(e => e.ClientName, opt => opt.MapFrom(e => e.Client.Name))
                .ForMember(e => e.Key, opt => opt.MapFrom(e => e.Key))
                .ForMember(e => e.Cpf, opt => opt.MapFrom(e => e.Client.Cpf.ToString()))
                .ForMember(e => e.TotalHours, opt => opt.MapFrom(e => e.TotalHours.ToInt()))
                .ForMember(e => e.VehicleFullName, opt => opt.MapFrom(e => $"{e.Vehicle.CarModel.CarBrand.Name} {e.Vehicle.CarModel.Name}"))
                .ForMember(e => e.HourPrice, opt => opt.MapFrom(e => e.Vehicle.HourPrice.ToString("C")))
                .ForMember(e => e.Category, opt => opt.MapFrom(e => e.Vehicle.Category.GetDescription()))
                .ForAllOtherMembers(e => e.Ignore());
        }
    }
}
