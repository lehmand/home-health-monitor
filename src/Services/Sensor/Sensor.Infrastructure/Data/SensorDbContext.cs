using Microsoft.EntityFrameworkCore;
using Sensor.Domain.Models;

namespace Sensor.Infrastructure.Data;

public class SensorDbContext(DbContextOptions<SensorDbContext> options) : DbContext(options)
{
    public DbSet<SensorTemperature> SensorTemperatures { get; set; } = null!;
}