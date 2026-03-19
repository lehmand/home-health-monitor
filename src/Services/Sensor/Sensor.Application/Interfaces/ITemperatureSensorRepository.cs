using Sensor.Application.DTOs;
using Sensor.Domain.Entities;

namespace Sensor.Application.Interfaces;

public interface ITemperatureSensorRepository
{
    Task<TemperatureSensorDto> CreateSensorAsync(TemperatureSensor tempSensor, CancellationToken cancellationToken);
    Task<IEnumerable<TemperatureSensorDto>> GetAllSensorsAsync(CancellationToken cancellationToken);
    Task<TemperatureSensorDto?> GetSensorByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task<TemperatureSensorDto> UpdateSensorAsync(TemperatureSensor tempSensor, CancellationToken cancellationToken);
    Task<bool> DeleteSensorAsync(Guid Id, CancellationToken cancellationToken);

}