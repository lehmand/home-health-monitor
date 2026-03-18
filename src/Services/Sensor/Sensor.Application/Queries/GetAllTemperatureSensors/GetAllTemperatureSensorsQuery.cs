using MediatR;
using Sensor.Application.DTOs;

namespace Sensor.Application.Queries.GetAllTemperatureSensors;

public record GetAllTemperatureSensorsQuery : IRequest<IEnumerable<TemperatureSensorDto>>;