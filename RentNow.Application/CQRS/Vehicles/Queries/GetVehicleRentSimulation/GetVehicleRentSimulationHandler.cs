using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentNow.Application.DTOs.Vehicle;
using RentNow.Application.Interfaces;
using RentNow.Application.Pattern.Strategy.Category;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.Vehicles.Queries.GetVehicleRentSimulation
{
    public class GetVehicleRentSimulationHandler : IRequestHandler<GetVehicleRentSimulationQuery, IResponse>
    {
        private readonly IResponse response;
        private readonly IEFContext context;
        private readonly IMapper mapper;
        private readonly ICategoryContext categoryContext;

        public GetVehicleRentSimulationHandler(IResponse response, IEFContext context, IMapper mapper, ICategoryContext categoryContext)
        {
            this.response = response;
            this.context = context;
            this.mapper = mapper;
            this.categoryContext = categoryContext;
        }

        public async Task<IResponse> Handle(GetVehicleRentSimulationQuery request, CancellationToken cancellationToken)
        {
            var chooseVehicle = context.Vehicle.Include(e => e.CarModel).FirstOrDefaultAsync(e => e.Key.Equals(request.VehicleKey)).Result;
            if (chooseVehicle is null)
            {
                return await response.Generate(hasError: true, message: $"Não foi possível encontrar o carro solicitado!");
            }
            
            var simulation = mapper.Map<VehicleRentSimulationDTO>(chooseVehicle);
            simulation.TotalPrice = categoryContext.GetCurrentCategoryCalculate(chooseVehicle.RentSimulation(request.TotalHours), chooseVehicle.Category.ToString()).ToString("C");
           
            return await response.Generate(collections: simulation);
        }

    }
}
