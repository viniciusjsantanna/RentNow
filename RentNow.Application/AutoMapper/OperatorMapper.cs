using AutoMapper;
using RentNow.Application.CQRS.Users.Inheritance.Operators.Commands;
using RentNow.Application.DTOs.User;
using RentNow.Application.DTOs.User.Operator;
using RentNow.Application.Extensions.Enum;
using RentNow.Domain.Entities;
using RentNow.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.AutoMapper
{
    public class OperatorMapper : Profile
    {
        public OperatorMapper()
        {
            CreateMap<RegisterOperatorCommand, Operator>()
               .ForPath(e => e.Credentials.Login, opt => opt.MapFrom(e => e.Registration))
               .ForPath(e => e.Credentials.Password, opt => opt.MapFrom(e => e.Password))
               .ForMember(e => e.Role, opt => opt.MapFrom(e => Role.Operator))
               .ForMember(e => e.Registration, opt => opt.MapFrom(e => e.Registration))
               .ForMember(e => e.Name, opt => opt.MapFrom(e => e.Name))
               .ForAllOtherMembers(e => e.Ignore());

            CreateMap<Operator, OperatorDTO>()
                .ForMember(e => e.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(e => e.Registration, opt => opt.MapFrom(e => e.Registration));

            CreateMap<Operator, UserDTOWithCredentials>()
                .ForMember(e => e.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(e => e.Login, opt => opt.MapFrom(e => e.Registration))
                .ForMember(e => e.Role, opt => opt.MapFrom(e => e.Role.GetDescription()));
        }
    }
}
