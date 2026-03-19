using MediatR;

namespace Sensor.Application.Commands.DeleteTemperatureSensor;

public record DeleteTemperatureSensorCommand(Guid Id) : IRequest<bool>;