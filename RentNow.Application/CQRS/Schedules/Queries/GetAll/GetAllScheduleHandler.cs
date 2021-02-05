﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentNow.Application.DTOs.Schedule;
using RentNow.Application.Interfaces;
using RentNow.Application.Pattern.Strategy.Category;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.Schedules.Queries.GetAll
{
    public class GetAllScheduleHandler : IRequestHandler<GetAllScheduleQuery, IResponse>
    {
        private readonly IResponse response;
        private readonly IEFContext context;
        private readonly IMapper mapper;
        private readonly CategoryContext categoryContext;

        public GetAllScheduleHandler(IResponse response, IEFContext context, IMapper mapper, CategoryContext categoryContext)
        {
            this.response = response;
            this.context = context;
            this.mapper = mapper;
            this.categoryContext = categoryContext;
        }

        public async Task<IResponse> Handle(GetAllScheduleQuery request, CancellationToken cancellationToken)
        {
            var schedules = context.Scheduling.Include(e => e.Vehicle).ThenInclude(e => e.CarModel).ThenInclude(e => e.CarBrand).Include(e => e.Client).ToListAsync().Result;
            var listSchedule = mapper.Map<List<ScheduleDTO>>(schedules);
            listSchedule.ForEach(e =>
            {
                var price = categoryContext.GetCurrentCategoryCalculate(e.HourPrice, e.TotalHours, e.Category.ToString());
                e.TotalPrice = price.ToString("C");
            });

            return await response.Generate(collections: listSchedule);
        }
    }
}
