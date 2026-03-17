using MediatR;
using Sensor.Application.Sensors.DTOs;
using Sensor.Application.Sensors.Interfaces;
using Sensor.Domain.Entities;

namespace Sensor.Application.Sensors.Commands.CreateTemperatureSensor;

public class CreateTemperatureSensorCommandHandler : IRequestHandler<CreateTemperatureSensorCommand, TemperatureSensorDto>
{
    private readonly ITemperatureSensorRepository _repository;
    public CreateTemperatureSensorCommandHandler(ITemperatureSensorRepository repository)
    {
        _repository = repository;
    }

    public async Task<TemperatureSensorDto> Handle(CreateTemperatureSensorCommand request, CancellationToken cancellationToken)
    {
        var entity = new TemperatureSensor
        {
            DeviceName = request.DeviceName,
            Room = request.Room,
            Location = request.Location
        };

        return await _repository.CreateSensorAsync(entity, cancellationToken);        
    }
}