using AutoMapper;
using RentNow.Application.CQRS.Users.Clients.Commands;
using RentNow.Application.DTOs.User;
using RentNow.Application.DTOs.User.Client;
using RentNow.Application.Extensions.Enum;
using RentNow.Domain.Entities;
using RentNow.Domain.Enum;
using System;

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
                .ForMember(e => e.Role, opt => opt.MapFrom(e => Role.Client))
                .ForMember(e => e.Cpf, opt => opt.MapFrom(e => e.Cpf))
                .ForMember(e => e.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(e => e.Birthdate, opt => opt.MapFrom(e => e.BirthDate))
                .ForAllOtherMembers(e => e.Ignore());

            CreateMap<Client, ClientDTO>()
                .ForMember(e => e.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(e => e.Cpf, opt => opt.MapFrom(e => e.Cpf))
                .ForMember(e => e.BirthDate, opt => opt.MapFrom(e => $"{(DateTime.Now.Year - e.Birthdate.Year).ToString()} anos"))
                .ForMember(e => e.Address, opt => opt.MapFrom(e => $"R.{e.Address.Street}, N°{e.Address.Number}, {e.Address.City} - {e.Address.State}, {e.Address.Postcode}, {e.Address.Complement} "));

            CreateMap<Client, UserDTOWithCredentials>()
                .ForMember(e => e.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(e => e.Login, opt => opt.MapFrom(e => e.Cpf))
                .ForMember(e => e.Role, opt => opt.MapFrom(e => e.Role.GetDescription()));
                
        }
    }
}
