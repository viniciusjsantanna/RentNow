using AutoMapper;
using RentNow.Application.CQRS.CarBrands.Commands.Register;
using RentNow.Application.DTOs.Brand;
using RentNow.Domain.Entities;

namespace RentNow.Application.AutoMapper
{
    public class CarBrandMapper : Profile
    {
        public CarBrandMapper()
        {
            CreateMap<RegisterCarBrandCommand, Brand>();

            CreateMap<Brand, BrandDTO>();
        }
    }
}
