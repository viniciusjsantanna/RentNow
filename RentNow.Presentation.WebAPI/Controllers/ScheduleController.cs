using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentNow.Application.CQRS.Schedules.Commands.Register;
using RentNow.Application.CQRS.Schedules.Queries.GetAll;
using RentNow.Application.Interfaces;
using System.Threading.Tasks;

namespace RentNow.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpPost]
        public Task<IResponse> RegisterSchedule(RegisterScheduleCommand command)
        {
            return mediator.Send(command);
        }
    }
}
