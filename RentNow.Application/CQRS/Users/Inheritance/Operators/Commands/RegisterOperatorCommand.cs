using MediatR;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.CQRS.Users.Inheritance.Operators.Commands
{
    public class RegisterOperatorCommand : IRequest<IResponse>
    {
        public string Name { get; set; }
        public string Registration { get; set; }
    }
}
