using Microsoft.EntityFrameworkCore;
using Sensor.Application.DTOs;
using Sensor.Application.Interfaces;
using Sensor.Domain.Entities;
using Sensor.Infrastructure.Data;

namespace Sensor.Infrastructure.Repositories;

public class TemperatureSensorRepository : ITemperatureSensorRepository
{
    private readonly SensorDbContext _context;

    public TemperatureSensorRepository(SensorDbContext context)
    {
        _context = context;
    }

    public async Task<TemperatureSensorDto> CreateAsync(TemperatureSensor sensor, CancellationToken cancellationToken)
    {
        sensor.Id = Guid.NewGuid();
        sensor.CreatedAt = DateTime.UtcNow;
        sensor.LastUpdated = DateTime.UtcNow;

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

    public async Task<IEnumerable<TemperatureSensorDto>> GetAllAsync(CancellationToken cancellationToken)
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

    public async Task<TemperatureSensorDto?> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        var sensor = await _context.TemperatureSensors.FirstOrDefaultAsync<TemperatureSensor>(s => s.Id == Id, cancellationToken);

        if (sensor is null) return null;

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

    public async Task<TemperatureSensorDto> UpdateAsync(TemperatureSensor tempSensor, CancellationToken cancellationToken)
    {
        var sensor = await _context.TemperatureSensors.FirstOrDefaultAsync(s => s.Id == tempSensor.Id, cancellationToken);

        if (sensor is null) throw new KeyNotFoundException($"SensorId with {tempSensor.Id}not found.");

        sensor.DeviceName = tempSensor.DeviceName;
        sensor.Room = tempSensor.Room;
        sensor.Location = tempSensor.Location;
        sensor.Temperature = tempSensor.Temperature;
        sensor.IsOnline = tempSensor.IsOnline;
        sensor.IsEnabled = tempSensor.IsEnabled;

        await _context.SaveChangesAsync(cancellationToken);

        return new TemperatureSensorDto
        {
           Id = sensor.Id,
           DeviceName = sensor.DeviceName,
           Room = sensor.Room,
           Temperature = sensor.Temperature,
           IsOnline = sensor.IsOnline,
           IsEnabled = sensor.IsEnabled
        };
    }

    public async Task<bool> DeleteAsync(Guid Id, CancellationToken cancellationToken)
    {
        var sensorToRemove = await _context.TemperatureSensors.SingleOrDefaultAsync(s => s.Id == Id, cancellationToken);

        if (sensorToRemove is null)
        {
            return false;
        } 

        _context.TemperatureSensors.Remove(sensorToRemove);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}