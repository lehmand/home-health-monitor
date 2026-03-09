using Microsoft.EntityFrameworkCore;
using Sensor.Domain.Entities;

namespace Sensor.Infrastructure.Data;

public class SensorDbContext(DbContextOptions<SensorDbContext> options) : DbContext(options)
{
    public DbSet<TemperatureSensor> TemperatureSensors { get; set; } = null!;
}