using MediatR;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.CQRS.Users.Clients.Commands
{
    public class RegisterClientCommand: IRequest<IResponse>
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Complement { get; set; }
        public string Password { get; set; }
    }
}
