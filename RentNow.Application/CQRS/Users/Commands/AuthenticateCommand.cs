using MediatR;
using RentNow.Application.Interfaces;
using RentNow.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.CQRS.Users.Commands
{
    public class AuthenticateCommand : IRequest<IResponse>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
