using System.Data.Common;
using MediatR;
using Sensor.Application.DTOs;
using Sensor.Application.Interfaces;
using Sensor.Domain.Entities;

namespace Sensor.Application.Queries.GetTemperatureSensorById;

public class GetTemperatureSensorByIdQueryHandler : IRequestHandler<GetTemperatureSensorByIdQuery, TemperatureSensorDto?>
{
    private readonly ITemperatureSensorRepository _repository;

    public GetTemperatureSensorByIdQueryHandler(ITemperatureSensorRepository repository)
    {
        _repository = repository;
    }

    public async Task<TemperatureSensorDto?> Handle(GetTemperatureSensorByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id, cancellationToken);
    }
}