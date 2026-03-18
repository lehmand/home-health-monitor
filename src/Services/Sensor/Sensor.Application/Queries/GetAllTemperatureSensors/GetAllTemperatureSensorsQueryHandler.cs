using MediatR;
using Sensor.Application.DTOs;
using Sensor.Application.Interfaces;

namespace Sensor.Application.Queries.GetAllTemperatureSensors;

public class GetAllTemperatureSensorsQueryHandler : IRequestHandler<GetAllTemperatureSensorsQuery, IEnumerable<TemperatureSensorDto>>
{
    private readonly ITemperatureSensorRepository _repository;
    public GetAllTemperatureSensorsQueryHandler(ITemperatureSensorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TemperatureSensorDto>> Handle(GetAllTemperatureSensorsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllSensorsAsync(cancellationToken);
    }
}