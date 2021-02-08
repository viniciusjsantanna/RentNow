using FluentValidation;
using RentNow.Application.CQRS.Vehicles.Commands.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.Validator.Vehicle
{
    public class RegisterVehicleValidator : AbstractValidator<RegisterVehicleCommand>
    {
        public RegisterVehicleValidator()
        {
            RuleFor(e => e.Plate)
                .NotEmpty()
                .WithMessage("O Campo placa é obrigatório!");

            RuleFor(e => e.Year)
                .NotNull()
                .WithMessage("O campo Ano é obrigatório!")
                .GreaterThan(0)
                .WithMessage("O campo Ano deve ser maior que zero!");

            RuleFor(e => e.HourPrice)
                .NotNull()
                .WithMessage("O campo Preço Hora é obrigatório!")
                .GreaterThan(0.0M)
                .WithMessage("O campo Preço Hora deve ser maior que zero!");

            RuleFor(e => e.TrunkLimit)
                .NotNull()
                .WithMessage("O campo Limite do Porta Mala é obrigatório!")
                .GreaterThan(0)
                .WithMessage("O campo Limite do Porta Mala deve ser maior que zero!");

            RuleFor(e => e.Fuel)
                .IsInEnum()
                .WithMessage("O campo Tipo de Combustível está inválido!");

            RuleFor(e => e.Category)
                .IsInEnum()
                .WithMessage("O campo Categoria está inválido!");

            RuleFor(e => e.CarModelKey)
                .NotNull()
                .WithMessage("A propriedade CarModelKey é obrigatório!");
        }
    }
}
