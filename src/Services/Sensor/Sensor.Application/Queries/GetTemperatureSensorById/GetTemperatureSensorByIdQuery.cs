using MediatR;
using Sensor.Application.DTOs;

namespace Sensor.Application.Queries.GetTemperatureSensorById;

public record GetTemperatureSensorByIdQuery(Guid Id) : IRequest<TemperatureSensorDto?>;