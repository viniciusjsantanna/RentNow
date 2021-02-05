using AutoMapper;
using RentNow.Application.CQRS.CarModels.Register;
using RentNow.Application.DTOs.CarModel;
using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.AutoMapper
{
    public class CarModelMapper : Profile
    {
        public CarModelMapper()
        {
            CreateMap<RegisterCarModelCommand, CarModel>()
                .ForMember(e => e.CarBrand, opt => opt.Ignore());

            CreateMap<CarModel, CarModelDTO>()
                .ForMember(e => e.BrandName, opt => opt.MapFrom(e => e.CarBrand.Name));
        }
    }
}
