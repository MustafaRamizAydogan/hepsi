using BarkodWeb.Entity.Entities;
using BarkodWeb.Service.FluentValidations;
using BarkodWeb.Service.Services.Abstractions;
using BarkodWeb.Service.Services.Concretes;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Reflection;

namespace BarkodWeb.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtansion(this IServiceCollection services)
        {

            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IMainGroupService, MainGroupService>();
            services.AddScoped<ILowerGroupService, LowerGroupService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Auto Service Yapısı------------

            services.AddAutoMapper(assembly);


            // Fluent Validations Service Yapısı----------------------------------------------

            //services.AddScoped<IValidator<Stock>, StockValidator>();


           





            return services;
        }
    }
}
