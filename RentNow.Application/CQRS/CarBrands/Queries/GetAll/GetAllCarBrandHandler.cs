using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentNow.Application.DTOs.Brand;
using RentNow.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.CarBrands.Queries.GetAll
{
    public class GetAllCarBrandHandler : IRequestHandler<GetAllCarBrandQuery, IResponse>
    {
        private readonly IResponse response;
        private readonly IEFContext context;
        private readonly IMapper mapper;

        public GetAllCarBrandHandler(IResponse response, IEFContext context, IMapper mapper)
        {
            this.response = response;
            this.context = context;
            this.mapper = mapper;
        }

        public Task<IResponse> Handle(GetAllCarBrandQuery request, CancellationToken cancellationToken)
        {
            var listBrand = mapper.Map<IList<BrandDTO>>(context.Brand.ToListAsync().Result);
            return response.Generate(collections: listBrand);
        }
    }
}
