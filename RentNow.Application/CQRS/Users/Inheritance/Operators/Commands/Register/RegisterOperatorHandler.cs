using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentNow.Application.Interfaces;
using RentNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.Users.Inheritance.Operators.Commands
{
    public class RegisterOperatorHandler : IRequestHandler<RegisterOperatorCommand, IResponse>
    {
        private readonly IResponse response;
        private readonly IEFContext context;
        private readonly IMapper mapper;

        public RegisterOperatorHandler(IResponse response, IEFContext context, IMapper mapper)
        {
            this.response = response;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IResponse> Handle(RegisterOperatorCommand request, CancellationToken cancellationToken)
        {
            var op = mapper.Map<Operator>(request);
            var existOperator = context.Operator.AnyAsync(e => e.Registration.registration.Equals(request.Registration)).Result;

            if (existOperator)
            {
                return await response.Generate(hasError: true, message: $"O Operador de matricula {request.Registration} já está cadastrado");
            }

            await context.Operator.AddAsync(op);
            var row = context.SaveChangesAsync(cancellationToken).Result;
            if(row <= 0)
            {
                return await response.Generate(hasError: true, message: $"Não foi possível cadastrar o operador {request.Name}!");
            }
            return await response.Generate(message: $"O Operador {request.Name} foi cadastrado com sucesso!");
        }
    }
}
