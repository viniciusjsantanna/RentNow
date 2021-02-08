using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RentNow.Application.DTOs;
using RentNow.Application.Interfaces;
using RentNow.Application.Pattern.Strategy.Category;

namespace RentNow.Application.IoC
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AppRegister(this IServiceCollection services)
        {
            services.AddTransient<IResponse, Response>();
            services.AddMediatR(typeof(ApplicationExtension).Assembly);
            services.AddAutoMapper(typeof(ApplicationExtension).Assembly);
            services.AddTransient<ICategoryCalculate, BasicConcreteCalculate>();
            services.AddTransient<ICategoryCalculate, CompleteConcreteCalculate>();
            services.AddTransient<ICategoryCalculate, LuxConcreteCalculate>();
            services.AddTransient(typeof(CategoryContext));
            return services;
        }
    }
}
