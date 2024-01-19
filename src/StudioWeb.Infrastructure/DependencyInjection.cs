using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudioWeb.Application.Abstruction;
using StudioWeb.Infrastructure.Data;

namespace StudioWeb.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
              this IServiceCollection services,
              IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, BotDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            return services;
        }
    }
}
