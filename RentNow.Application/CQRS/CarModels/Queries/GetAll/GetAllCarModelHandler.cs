using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentNow.Application.DTOs.CarModel;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.CarModels.Queries.GetAll
{
    public class GetAllCarModelHandler : IRequestHandler<GetAllCarModelQuery, IResponse>
    {
        private readonly IResponse response;
        private readonly IEFContext context;
        private readonly IMapper mapper;

        public GetAllCarModelHandler(IResponse response, IEFContext context, IMapper mapper)
        {
            this.response = response;
            this.context = context;
            this.mapper = mapper;
        }

        public Task<IResponse> Handle(GetAllCarModelQuery request, CancellationToken cancellationToken)
        {
            var listModels = mapper.Map<IList<CarModelDTO>>(context.CarModel.Include(e => e.CarBrand).ToListAsync().Result);
            return response.Generate(collections: listModels);
        }
    }
}
