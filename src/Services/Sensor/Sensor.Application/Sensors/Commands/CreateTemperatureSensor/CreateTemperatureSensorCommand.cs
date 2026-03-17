using MediatR;
using Sensor.Application.Sensors.DTOs;

namespace Sensor.Application.Sensors.Commands.CreateTemperatureSensor;

public record CreateTemperatureSensorCommand : IRequest<TemperatureSensorDto>
{
    public required string DeviceName { get; init; }
    public string? Room { get; init; }
    public string? Location { get; init; }
}