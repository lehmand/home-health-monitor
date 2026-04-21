using Sensor.Application.DTOs;
using Sensor.Domain.Entities;

namespace Sensor.Application.Interfaces;

public interface ITemperatureSensorRepository
{
    Task<TemperatureSensorDto> CreateAsynnc(TemperatureSensor tempSensor, CancellationToken cancellationToken);
    Task<IEnumerable<TemperatureSensorDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<TemperatureSensorDto?> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task<TemperatureSensorDto> UpdateAsync(TemperatureSensor tempSensor, CancellationToken cancellationToken);
    Task<bool> DeleteAsync (Guid Id, CancellationToken cancellationToken);

}