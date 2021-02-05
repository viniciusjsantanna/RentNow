using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentNow.Application.CQRS.Schedules.Commands.Register;
using RentNow.Application.CQRS.Vehicles.Commands.Register;
using RentNow.Application.CQRS.Vehicles.Queries.GetAll;
using RentNow.Application.CQRS.Vehicles.Queries.GetChecklistPrice;
using RentNow.Application.CQRS.Vehicles.Queries.GetVehicleRentSimulation;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentNow.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator mediator;

        public VehicleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public Task<IResponse> Register(RegisterVehicleCommand command)
        {
            return mediator.Send(command);
        }

        [HttpGet]
        public Task<IResponse> GetAll()
        {
            return mediator.Send(new GetAllVehicleQuery());
        }

        [HttpGet]
        [Route("RentSimulation")]
        public Task<IResponse> GetVehicleRentSimulation([FromQuery] Guid vehicleKey, int totalHours)
        {
            return mediator.Send(new GetVehicleRentSimulationQuery(vehicleKey, totalHours));
        }

        [HttpPost]
        [Route("Schedule")]
        public Task<IResponse> RegisterSchedule(RegisterScheduleCommand command)
        {
            return mediator.Send(command);
        }

        [HttpGet]
        [Route("Checklist")]
        public Task<IResponse> GetChecklistPrice([FromQuery] bool isClearCar, bool isFullTank, bool isCrashed, bool isScratched, Guid ScheduleKey)
        {
            return mediator.Send(new GetChecklistPriceQuery(isClearCar, isFullTank, isCrashed, isScratched, ScheduleKey));
        }
    }
}
