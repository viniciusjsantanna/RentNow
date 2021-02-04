using AutoMapper;
using MediatR;
using RentNow.Application.Interfaces;
using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.CarModels.Register
{
    public class RegisterCarModelHandler : IRequestHandler<RegisterCarModelCommand, IResponse>
    {
        private readonly IResponse response;
        private readonly IEFContext context;
        private readonly IMapper mapper;

        public RegisterCarModelHandler(IResponse response, IEFContext context, IMapper mapper)
        {
            this.response = response;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IResponse> Handle(RegisterCarModelCommand request, CancellationToken cancellationToken)
        {
            var brand = context.Brand.FindAsync(request.BrandKey).Result;
            var carModel = mapper.Map<CarModel>(request);
            carModel.CarBrand = brand;
            if(carModel is null)
            {
                return await response.Generate(hasError: true, message: $"Não foi possível cadastrar o modelo informado!");
            }

            await context.CarModel.AddAsync(carModel);
            var row = context.SaveChangesAsync(cancellationToken).Result;

            if(row <= 0)
            {
                return await response.Generate(hasError: true, message: $"Não foi possível cadastrar o modelo informado!");
            }
            return await response.Generate(message: $"O Modelo {request.Name} foi cadastrado com sucesso!");
            throw new NotImplementedException();
        }
    }
}
