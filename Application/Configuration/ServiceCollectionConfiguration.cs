using InfraStructure.Context;
using InfraStructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ViajaNet.Application.Contracts;
using ViajaNet.Application.Services;

namespace Application.Configuration
{
    public static class ServiceCollectionConfiguration
    {
        public static void ConfigureViajaNetServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IVisitQueueService, VisitQueueService>();
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
