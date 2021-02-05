using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentNow.Application.CQRS.Vehicles.Commands.Register;
using RentNow.Application.CQRS.Vehicles.Queries.GetAll;
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
    }
}
