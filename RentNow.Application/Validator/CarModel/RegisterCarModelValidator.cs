using FluentValidation;
using RentNow.Application.CQRS.CarModels.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.Validator.CarModel
{
    public class RegisterCarModelValidator : AbstractValidator<RegisterCarModelCommand>
    {
        public RegisterCarModelValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("O Campo Nome é obrigatório!");

            RuleFor(e => e.BrandKey)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe o Id da marca!");
        }
    }
}
