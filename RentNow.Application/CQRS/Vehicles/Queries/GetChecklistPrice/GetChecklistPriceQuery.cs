using MediatR;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.CQRS.Vehicles.Queries.GetChecklistPrice
{
    public class GetChecklistPriceQuery : IRequest<IResponse>
    {
        public GetChecklistPriceQuery(bool isClearCar, bool isFullTank, bool isCrashed, bool isScratched, Guid scheduleKey)
        {
            this.isClearCar = isClearCar;
            this.isFullTank = isFullTank;
            this.isCrashed = isCrashed;
            this.isScratched = isScratched;
            ScheduleKey = scheduleKey;
        }

        public bool isClearCar { get; set; }
        public bool isFullTank { get; set; }
        public bool isCrashed { get; set; }
        public bool isScratched { get; set; }
        public Guid ScheduleKey { get; set; }
    }
}
