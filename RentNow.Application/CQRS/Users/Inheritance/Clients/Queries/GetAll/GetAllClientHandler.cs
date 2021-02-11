using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentNow.Application.DTOs.User.Client;
using RentNow.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.Users.Inheritance.Clients.Queries.GetAll
{
    public class GetAllClientHandler : IRequestHandler<GetAllClientQuery, IResponse>
    {
        private readonly IResponse response;
        private readonly IEFContext context;
        private readonly IMapper mapper;

        public GetAllClientHandler(IResponse response, IEFContext context, IMapper mapper)
        {
            this.response = response;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IResponse> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
        {
            var listClients = mapper.Map<IList<ClientDTO>>(context.Client.OrderBy(e => e.Name.name).ToListAsync().Result);
            return await response.Generate(collections: listClients);
        }
    }
}
