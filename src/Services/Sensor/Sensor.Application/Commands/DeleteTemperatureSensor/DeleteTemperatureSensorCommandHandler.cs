using MediatR;
using Sensor.Application.Interfaces;

namespace Sensor.Application.Commands.DeleteTemperatureSensor;

public class DeleteTemperatureSensorCommandHandler : IRequestHandler<DeleteTemperatureSensorCommand, bool>
{
    private readonly ITemperatureSensorRepository _repository;

    public DeleteTemperatureSensorCommandHandler(ITemperatureSensorRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteTemperatureSensorCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id, cancellationToken);
    }
}