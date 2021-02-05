using MediatR;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.CQRS.Schedules.Queries.GetAll
{
    public class GetAllScheduleQuery : IRequest<IResponse>
    {
    }
}
