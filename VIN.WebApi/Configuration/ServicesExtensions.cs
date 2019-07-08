using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VIN.Application.Automapper;
using VIN.Application.Interfaces;

namespace VIN_Management.Configuration
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAutoMapperSetup<T>(this IServiceCollection services)
            where T : class, IAutoMapperConfig, new()
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            AutoMapperConfigFactory<T>.Create().RegisterMappings();

            return services;

        }
    }
}
