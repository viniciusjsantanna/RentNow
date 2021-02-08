using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentNow.Application.CQRS.Schedules.Queries.GetAll;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentNow.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IMediator mediator;

        public ScheduleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<IResponse> GetAll()
        {
            return mediator.Send(new GetAllScheduleQuery());
        }
    }
}
