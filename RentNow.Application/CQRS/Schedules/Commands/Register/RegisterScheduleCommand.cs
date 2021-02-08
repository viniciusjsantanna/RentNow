using MediatR;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.CQRS.Schedules.Commands.Register
{
    public class RegisterScheduleCommand : IRequest<IResponse>
    {
        public string Cpf { get; set; }
        public Guid VehicleKey { get; set; }
        public int TotalHours { get; set; }
    }
}
