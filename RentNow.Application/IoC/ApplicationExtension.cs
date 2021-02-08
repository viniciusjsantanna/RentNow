using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RentNow.Application.DTOs;
using RentNow.Application.Interfaces;
using RentNow.Application.Jwt;
using RentNow.Application.Pattern.Strategy.Category;
using RentNow.Application.Pattern.Strategy.Login;
using RentNow.Application.Pipeline;

namespace RentNow.Application.IoC
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AppRegister(this IServiceCollection services)
        {
            services.AddTransient<IResponse, Response>();
            services.AddMediatR(typeof(ApplicationExtension).Assembly);
            services.AddAutoMapper(typeof(ApplicationExtension).Assembly);
            services.AddTransient<ICategoryHandler, BasicConcrete>();
            services.AddTransient<ICategoryHandler, CompleteConcrete>();
            services.AddTransient<ICategoryHandler, LuxConcrete>();
            services.AddTransient<ICategoryContext, CategoryContext>();
            services.AddTransient<ILoginContext, LoginContext>();
            services.AddTransient<ILoginHandler, ClientConcrete>();
            services.AddTransient<ILoginHandler, OperatorConcrete>();
            services.AddTransient<ITokenGenerator, JwtGenerator>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(ApplicationExtension).Assembly);


            return services;
        }
    }
}
