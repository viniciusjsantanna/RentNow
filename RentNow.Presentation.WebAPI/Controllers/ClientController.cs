using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentNow.Application.CQRS.Users.Clients.Commands;
using RentNow.Application.CQRS.Users.Inheritance.Clients.Queries.GetAll;
using RentNow.Application.Interfaces;
using System.Threading.Tasks;

namespace RentNow.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator mediator;

        public ClientController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public Task<IResponse> Register(RegisterClientCommand command)
        {
            return mediator.Send(command);
        }

        [HttpGet]
        [Authorize]
        public Task<IResponse> GetAll()
        {
            return mediator.Send(new GetAllClientQuery());
        }
    }
}
