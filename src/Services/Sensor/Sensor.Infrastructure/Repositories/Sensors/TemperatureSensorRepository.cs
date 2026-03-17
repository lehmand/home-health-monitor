using Sensor.Application.Sensors.Commands.CreateTemperatureSensor;
using Sensor.Application.Sensors.DTOs;
using Sensor.Application.Sensors.Interfaces;
using Sensor.Domain.Entities;
using Sensor.Infrastructure.Data;

namespace Sensor.Infrastructure.Repositories.Sensors;

public class TemperatureSensorRepository : ITemperatureSensorRepository
{
    private readonly SensorDbContext _context;

    public TemperatureSensorRepository(SensorDbContext context)
    {
        _context = context;
    }

    public async Task<TemperatureSensorDto> CreateSensorAsync(TemperatureSensor sensor, CancellationToken cancellationToken)
    {
        sensor.Id = Guid.NewGuid();
        sensor.CreatedAt = DateTime.Now;
        sensor.LastUpdated = DateTime.Now;

        _context.TemperatureSensors.Add(sensor);
        await _context.SaveChangesAsync(cancellationToken);

        return new TemperatureSensorDto
        {
          Id = sensor.Id,
          DeviceName = sensor.DeviceName,
          Room = sensor.Room,
          Location = sensor.Location,
          Temperature = sensor.Temperature,
          IsOnline = sensor.IsOnline,
          IsEnabled = sensor.IsEnabled  
        };
    }
}