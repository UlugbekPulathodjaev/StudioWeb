﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace StudioWeb.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
