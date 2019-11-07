using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace Checkout.API.Extensions
{
    public static class ServiceConfigExtensions
    {
        public static IServiceCollection AddSystemServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Checkout API", Version = "v1" });
            });

            return services;
        }
    }
}