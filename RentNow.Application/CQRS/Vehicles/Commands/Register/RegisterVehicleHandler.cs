using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentNow.Application.Interfaces;
using RentNow.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.Vehicles.Commands.Register
{
    public class RegisterVehicleHandler : IRequestHandler<RegisterVehicleCommand, IResponse>
    {
        private readonly IResponse response;
        private readonly IEFContext context;
        private readonly IMapper mapper;

        public RegisterVehicleHandler(IResponse response, IEFContext context, IMapper mapper)
        {
            this.response = response;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IResponse> Handle(RegisterVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = mapper.Map<Vehicle>(request);
            vehicle.CarModel = context.CarModel.Include(e => e.CarBrand).FirstOrDefaultAsync(e => e.Key.Equals(request.CarModelKey)).Result;

            await context.Vehicle.AddAsync(vehicle);
            var row = context.SaveChangesAsync(cancellationToken).Result;
            if (row <= 0)
            {
                return await response.Generate(hasError: true, message: $"Não foi possível cadastrar o veículo informado!");
            }
            return await response.Generate(message: $"O Veículo {vehicle.CarModel.CarBrand.Name} {vehicle.CarModel.Name} foi cadastrado com sucesso!");
        }
    }
}
