using Sensor.Application.Sensors.DTOs;
using Sensor.Domain.Entities;

namespace Sensor.Application.Sensors.Interfaces;

public interface ITemperatureSensorRepository
{
    Task<IEnumerable<TemperatureSensorDto>> GetAllSensorsAsync(CancellationToken cancellationToken);
    Task<TemperatureSensorDto?> GetSensorByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task<TemperatureSensorDto> CreateSensorAsync(TemperatureSensor tempSensor, CancellationToken cancellationToken);
    Task DeleteSensorAsync(Guid Id, CancellationToken cancellationToken);
    Task<TemperatureSensorDto> UpdateSensorAsync(TemperatureSensor tempSensor, CancellationToken cancellationToken);

}