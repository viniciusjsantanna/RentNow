using MediatR;
using RentNow.Application.Interfaces;
using System;

namespace RentNow.Application.CQRS.Vehicles.Queries.GetVehicleRentSimulation
{
    public class GetVehicleRentSimulationQuery : IRequest<IResponse>
    {
        public GetVehicleRentSimulationQuery(Guid vehicleKey, int totalHours)
        {
            VehicleKey = vehicleKey;
            TotalHours = totalHours;
        }

        public Guid VehicleKey { get; private set; }
        public int TotalHours { get; private set; }
    }
}
