using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentNow.Application.Interfaces;
using RentNow.Application.Pattern.Strategy.Category;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.Vehicles.Queries.GetChecklistPrice
{
    public class GetChecklistPriceHandler : IRequestHandler<GetChecklistPriceQuery, IResponse>
    {
        private readonly IResponse response;
        private readonly IEFContext context;
        private readonly IMapper mapper;
        private readonly ICategoryContext categoryContext;

        public GetChecklistPriceHandler(IResponse response, IEFContext context, IMapper mapper, ICategoryContext categoryContext)
        {
            this.response = response;
            this.context = context;
            this.mapper = mapper;
            this.categoryContext = categoryContext;
        }

        public Task<IResponse> Handle(GetChecklistPriceQuery request, CancellationToken cancellationToken)
        {
            var schedule = context.Scheduling.Include(e => e.Vehicle).FirstOrDefaultAsync(e => e.Key.Equals(request.ScheduleKey)).Result;
            var totalPrice = categoryContext.GetCurrentCategoryCalculate(schedule.Vehicle.RentSimulation(schedule.TotalHours.ToInt()), schedule.Vehicle.Category.ToString());
            var total = totalPrice * CalculateChecklist(request);
            return response.Generate(collections: total.ToString("C"));
        }

        private decimal CalculateChecklist(GetChecklistPriceQuery request)
        {
            var totalPercents = 0.0M;
            if (request.isClearCar)
            {
                totalPercents += 0.3M;
            }
            if (request.isCrashed)
            {
                totalPercents += 0.3M;
            }
            if (request.isFullTank)
            {
                totalPercents += 0.3M;
            }
            if (request.isScratched)
            {
                totalPercents += 0.3M;
            }
            return totalPercents;
        }
    }
}
