using MediatR;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.CQRS.CarModels.Register
{
    public class RegisterCarModelCommand : IRequest<IResponse>
    {
        public string Name { get; set; }
        public Guid BrandKey { get; set; }
    }
}
