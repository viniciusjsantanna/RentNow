using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentNow.Application.DTOs.User.Operator;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.Users.Inheritance.Operators.Queries.GetAll
{
    public class GetAllOperatorHandler : IRequestHandler<GetAllOperatorQuery, IResponse>
    {
        private readonly IResponse response;
        private readonly IEFContext context;
        private readonly IMapper mapper;

        public GetAllOperatorHandler(IResponse response, IEFContext context, IMapper mapper)
        {
            this.response = response;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IResponse> Handle(GetAllOperatorQuery request, CancellationToken cancellationToken)
        {
            var listOperators = mapper.Map<IList<OperatorDTO>>(context.Operator.OrderBy(e => e.Name.name).ToListAsync().Result);
            return await response.Generate(collections: listOperators);
        }
    }
}
