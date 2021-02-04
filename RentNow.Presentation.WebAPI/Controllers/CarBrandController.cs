using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentNow.Application.CQRS.CarBrands.Commands.Register;
using RentNow.Application.CQRS.CarBrands.Queries.GetAll;
using RentNow.Application.Interfaces;
using System.Threading.Tasks;

namespace RentNow.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarBrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public Task<IResponse> Register(RegisterCarBrandCommand command)
        {
            return mediator.Send(command);
        }

        [HttpGet]
        public Task<IResponse> GetAll()
        {
            return mediator.Send(new GetAllCarBrandQuery());
        }
    }
}
