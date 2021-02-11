using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var existModel = context.CarModel.AnyAsync(e => e.Name.name.Equals(request.Name)).Result;
            var brand = context.Brand.FindAsync(request.BrandKey).Result;
            var carModel = mapper.Map<CarModel>(request);

            if (existModel)
            {
                return await response.Generate(hasError: true, message: $"O modelo {request.Name} já foi cadastrado!");
            }

            if (brand is null )
            {
                return await response.Generate(hasError: true, message: $"Não foi possível encontrar a marca informada!");
            }
            carModel.CarBrand = brand;

            await context.CarModel.AddAsync(carModel);
            var row = context.SaveChangesAsync(cancellationToken).Result;

            if(row <= 0)
            {
                return await response.Generate(hasError: true, message: $"Não foi possível cadastrar o modelo informado!");
            }
            return await response.Generate(message: $"O Modelo {request.Name} foi cadastrado com sucesso!");
        }
    }
}
