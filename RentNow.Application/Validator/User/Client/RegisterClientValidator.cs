using FluentValidation;
using RentNow.Application.CQRS.Users.Clients.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentNow.Application.Validator.User.Client
{
    public class RegisterClientValidator : AbstractValidator<RegisterClientCommand>
    {
        public RegisterClientValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .WithMessage("O campo Nome é obrigatório!");

            RuleFor(e => e.Cpf)
                .MaximumLength(11)
                .WithMessage("O campo CPF deve conter 11 caracteres!")
                .NotEmpty()
                .WithMessage("O campo CPF é obrigatório!");

            RuleFor(e => e.BirthDate)
                .NotNull()
                .WithMessage("O campo Data de Nascimento é obrigatório!");

            RuleFor(e => e.Street)
                .NotEmpty()
                .WithMessage("O campo Rua é obrigatório!");

            RuleFor(e => e.Number)
                .NotEmpty()
                .WithMessage("O campo Número é obrigatório!");

            RuleFor(e => e.City)
                .NotEmpty()
                .WithMessage("O campo Cidade é obrigatório!");


            RuleFor(e => e.Postcode)
                .NotEmpty()
                .WithMessage("O campo CEP é obrigatório!");

            RuleFor(e => e.State)
                .NotEmpty()
                .WithMessage("O campo Estado é obrigatório!");

        }
    }
}
