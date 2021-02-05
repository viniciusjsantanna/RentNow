using MediatR;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.CQRS.CarModels.Queries.GetAll
{
    public class GetAllCarModelQuery : IRequest<IResponse>
    {
    }
}
