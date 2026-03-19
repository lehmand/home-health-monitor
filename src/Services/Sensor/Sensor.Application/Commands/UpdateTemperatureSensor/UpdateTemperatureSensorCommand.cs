using MediatR;
using Sensor.Application.DTOs;

namespace Sensor.Application.Commands.UpdateTemperatureSensor;

public record UpdateTemperatureSensorCommand : IRequest<TemperatureSensorDto>
{
    public required Guid Id { get; init; }
    public required string DeviceName { get; init; }
    public string? Room { get; init; }
    public string? Location { get; init; }
    public bool IsEnabled { get; init; }
}