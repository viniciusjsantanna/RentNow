using AutoMapper;
using RentNow.Application.CQRS.Users.Clients.Commands;
using RentNow.Domain.Entities;
using RentNow.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.AutoMapper
{
    public class ClientMapper : Profile
    {
        public ClientMapper()
        {
            CreateMap<RegisterClientCommand, Client>()
                .ForPath(e => e.Address.Street, opt => opt.MapFrom(e => e.Street))
                .ForPath(e => e.Address.Number, opt => opt.MapFrom(e => e.Number))
                .ForPath(e => e.Address.State, opt => opt.MapFrom(e => e.State))
                .ForPath(e => e.Address.City, opt => opt.MapFrom(e => e.City))
                .ForPath(e => e.Address.Postcode, opt => opt.MapFrom(e => e.Postcode))
                .ForPath(e => e.Address.Complement, opt => opt.MapFrom(e => e.Complement))
                .ForPath(e => e.Credentials.Login, opt => opt.MapFrom(e => e.Cpf))
                .ForPath(e => e.Credentials.Password, opt => opt.MapFrom(e => e.Password))
                .ForMember(e => e.Role, opt => opt.MapFrom(e => Role.Client));
        }
    }
}
