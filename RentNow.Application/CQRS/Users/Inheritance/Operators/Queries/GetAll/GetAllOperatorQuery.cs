using MediatR;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.CQRS.Users.Inheritance.Operators.Queries.GetAll
{
    public class GetAllOperatorQuery : IRequest<IResponse>
    {
    }
}
