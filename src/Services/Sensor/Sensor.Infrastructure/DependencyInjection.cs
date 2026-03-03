using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sensor.Infrastructure.Data;

namespace Sensor.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContextPool<SensorDbContext>(opt => 
        opt.UseNpgsql(configuration.GetConnectionString("SensorDb")));

        return services;
    }
}