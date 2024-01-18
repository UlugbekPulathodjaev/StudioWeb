using Microsoft.Extensions.DependencyInjection;
using StudioWeb.Application.Customers;

namespace StudioWeb.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
