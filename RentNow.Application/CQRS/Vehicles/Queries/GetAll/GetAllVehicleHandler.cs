using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentNow.Application.DTOs.Vehicle;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.Vehicles.Queries.GetAll
{
    public class GetAllVehicleHandler : IRequestHandler<GetAllVehicleQuery, IResponse>
    {
        private readonly IResponse response;
        private readonly IEFContext context;
        private readonly IMapper mapper;

        public GetAllVehicleHandler(IResponse response, IEFContext context, IMapper mapper)
        {
            this.response = response;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IResponse> Handle(GetAllVehicleQuery request, CancellationToken cancellationToken)
        {
            var listVehicle = mapper.Map<IList<VehicleDTO>>(context.Vehicle
                                                                   .Include(e => e.CarBrand)
                                                                   .Include(e => e.CarModel)
                                                                   .ToListAsync().Result);

            return await response.Generate(collections: listVehicle);
        }
    }
}
