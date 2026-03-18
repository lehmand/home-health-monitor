using Microsoft.EntityFrameworkCore;
using Sensor.Application.DTOs;
using Sensor.Application.Interfaces;
using Sensor.Domain.Entities;
using Sensor.Infrastructure.Data;
using System.Linq;

namespace Sensor.Infrastructure.Repositories;

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

    public async Task<IEnumerable<TemperatureSensorDto>> GetAllSensorsAsync(CancellationToken cancellationToken)
    {
        var sensors = await _context.TemperatureSensors.ToListAsync(cancellationToken);

        return sensors.Select(sensor => new TemperatureSensorDto
        {
          Id = sensor.Id,
          DeviceName = sensor.DeviceName,
          Room = sensor.Room,
          Location = sensor.Location,
          Temperature = sensor.Temperature,
          IsOnline = sensor.IsOnline,
          IsEnabled = sensor.IsEnabled
        });
    }
}