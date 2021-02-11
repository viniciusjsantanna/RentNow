using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentNow.Application.Interfaces;
using RentNow.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.Users.Clients.Commands
{
    public class RegisterClientHandler : IRequestHandler<RegisterClientCommand, IResponse>
    {
        private readonly IResponse response;
        private readonly IEFContext context;
        private readonly IMapper mapper;

        public RegisterClientHandler(IResponse response, IEFContext context, IMapper mapper)
        {
            this.response = response;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IResponse> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            var client = mapper.Map<Client>(request);
            var existClient = context.Client.AnyAsync(e => e.Cpf.cpf.Equals(request.Cpf)).Result;

            if (existClient)
            {
                return await response.Generate(hasError: true, message: $"O cliente dono do CPF {request.Cpf} já está cadastrado");
            }

            await context.Client.AddAsync(client);
            var row = context.SaveChangesAsync(cancellationToken).Result;
            if(row <= 0)
            {
                return await response.Generate(hasError: true, message: $"Não foi possível cadastrar o cliente {request.Name}!");
            }
            return await response.Generate(message: $"O Cliente {request.Name} foi cadastrado com sucesso!");
        }
    }
}
