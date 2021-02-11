using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentNow.Application.Interfaces;
using RentNow.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.CarBrands.Commands.Register
{
    public class RegisterCarBrandHandler : IRequestHandler<RegisterCarBrandCommand, IResponse>
    {
        private readonly IResponse response;
        private readonly IEFContext context;
        private readonly IMapper mapper;

        public RegisterCarBrandHandler(IResponse response, IEFContext context, IMapper mapper)
        {
            this.response = response;
            this.context = context;
            this.mapper = mapper;
        }

        public Task<IResponse> Handle(RegisterCarBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = mapper.Map<Brand>(request);

            var existBrand = context.Brand.AnyAsync(e => e.Name.name.Equals(request.Name)).Result;

            if (existBrand)
            {
                return response.Generate(hasError: true, message: $"A marca {request.Name} já foi cadastrado!");
            }

            context.Brand.Add(brand);
            var row = context.SaveChangesAsync(cancellationToken).Result;
            if (row <= 0)
            {
                return response.Generate(hasError: true, message: $"Não foi possível cadastrar a marca {request.Name}");
            }

            return response.Generate(message: $"A marca {request.Name} foi cadastrada com sucesso!");
        }

    }
}
