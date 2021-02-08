using FluentValidation;
using RentNow.Application.CQRS.Users.Inheritance.Operators.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.Validator.User.Operator
{
    public class RegisterOperatorValidator : AbstractValidator<RegisterOperatorCommand>
    {
        public RegisterOperatorValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("O campo Nome é obrigatório!");

            RuleFor(e => e.Registration)
                .MaximumLength(6)
                .WithMessage("O campo Matricula deve conter 6 caracteres!")
                .NotEmpty()
                .WithMessage("O campo Matricula é Obrigatório!");
        }
    }
}
