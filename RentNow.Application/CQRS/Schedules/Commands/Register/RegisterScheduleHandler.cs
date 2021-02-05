using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentNow.Application.Interfaces;
using RentNow.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.CQRS.Schedules.Commands.Register
{
    public class RegisterScheduleHandler : IRequestHandler<RegisterScheduleCommand, IResponse>
    {
        private readonly IResponse response;
        private readonly IEFContext context;
        private readonly IMapper mapper;

        public RegisterScheduleHandler(IResponse response, IEFContext context, IMapper mapper)
        {
            this.response = response;
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IResponse> Handle(RegisterScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = mapper.Map<Scheduling>(request);
            schedule.Vehicle = context.Vehicle.FindAsync(request.VehicleKey).Result;
            schedule.Client = context.Client.FirstOrDefaultAsync(e => e.Cpf.cpf.Equals(request.Cpf)).Result;

            await ValidateSchedule(schedule);

            await context.Scheduling.AddAsync(schedule);
            var row = context.SaveChangesAsync(cancellationToken).Result;
            if(row <= 0)
            {
                return await response.Generate(hasError: true, message: $"Não foi possível fazer o agendamento previsto para o veículo informado!");
            }

            return await response.Generate(message: $"O agendamento foi realizado com sucesso!");
        }

        private async Task<IResponse> ValidateSchedule(Scheduling schedule)
        {
            if (schedule.Vehicle is null && schedule.Client is null)
            {
                return await response.Generate(hasError: true, message: $"Não foi possível encontrar o carro e o cliente informado!");
            }
            else if (schedule.Client is null)
            {
                return await response.Generate(hasError: true, message: $"Não foi possível encontrar o cliente informado!");
            }
            else if (schedule.Vehicle is null)
            {
                return await response.Generate(hasError: true, message: $"Não foi possível encontrar o carro informado!");
            }
            return response;
        }
    }
}
