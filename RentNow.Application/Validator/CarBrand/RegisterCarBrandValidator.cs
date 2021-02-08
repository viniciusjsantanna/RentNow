using FluentValidation;
using RentNow.Application.CQRS.CarBrands.Commands.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.Validator.CarBrand
{
    public class RegisterCarBrandValidator : AbstractValidator<RegisterCarBrandCommand>
    {
        public RegisterCarBrandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("Campo Nome é obrigatório!");
        }
    }
}
