using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentNow.Application.CQRS.CarModels.Queries.GetAll;
using RentNow.Application.CQRS.CarModels.Register;
using RentNow.Application.Interfaces;
using System.Threading.Tasks;

namespace RentNow.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarModelController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarModelController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public Task<IResponse> Register(RegisterCarModelCommand command)
        {
            return mediator.Send(command);
        }

        [HttpGet]
        public Task<IResponse> GetAll()
        {
            return mediator.Send(new GetAllCarModelQuery());
        }
    }
}
