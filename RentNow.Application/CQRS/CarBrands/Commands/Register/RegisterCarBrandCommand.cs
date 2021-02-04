using MediatR;
using RentNow.Application.Interfaces;

namespace RentNow.Application.CQRS.CarBrands.Commands.Register
{
    public class RegisterCarBrandCommand : IRequest<IResponse>
    {
        public string Name { get; set; }
    }
}
