using MediatR;
using Sensor.Application.DTOs;
using Sensor.Application.Interfaces;
using Sensor.Domain.Entities;

namespace Sensor.Application.Commands.UpdateTemperatureSensor;

public class UpdateTemperatureSensorCommandHandler : IRequestHandler<UpdateTemperatureSensorCommand, TemperatureSensorDto>
{
    private readonly ITemperatureSensorRepository _repository;

    public UpdateTemperatureSensorCommandHandler(ITemperatureSensorRepository repository)
    {
        _repository = repository;
    }

    public async Task<TemperatureSensorDto> Handle(UpdateTemperatureSensorCommand request, CancellationToken cancellationToken)
    {
        var entity = new TemperatureSensor
        {
          Id = request.Id,
          DeviceName = request.DeviceName,
          Room = request.Room,
          Location = request.Location,
          IsEnabled = request.IsEnabled
        };

        return await _repository.UpdateAsync(entity, cancellationToken);
    }
}