using FluentValidation;
using FluentValidation.Results;
using MediatR;
using RentNow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RentNow.Application.Pipeline
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : class
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;
        private readonly IResponse response;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IResponse response)
        {
            this.validators = validators;
            this.response = response;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {

            var failures = validators.Select(e => e.Validate(request))
                                     .SelectMany(e => e.Errors)
                                     .Where(e => e != null)
                                     .ToList();

            return failures.Any() ? await GenerateErrorMessage(failures) as TResponse : await next();
        }

        private async Task<IResponse> GenerateErrorMessage(List<ValidationFailure> errors)
        {
            errors.ForEach(e =>
            {
                response.AddMessagesToList(e.ErrorMessage);
            });
            return await response.Generate();
        }
    }
}
