using FluentValidation;
using RentNow.Application.CQRS.Schedules.Commands.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.Validator.Schedule
{
    public class RegisterScheduleValidator : AbstractValidator<RegisterScheduleCommand>
    {
        public RegisterScheduleValidator()
        {
            RuleFor(e => e.Cpf)
                 .NotEmpty()
                 .WithMessage("O campo CPF é obrigatório!");

            RuleFor(e => e.TotalHours)
                .GreaterThan(0)
                .WithMessage("O campo Total de Horas deve ser maior que zero!");

            RuleFor(e => e.VehicleKey)
                .NotNull()
                .WithMessage("A propriedade VehicleKey é obrigatória!");
        }
    }
}
