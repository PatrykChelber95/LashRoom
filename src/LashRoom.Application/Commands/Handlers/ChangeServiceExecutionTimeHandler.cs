using LashRoom.Application.Abstractions;
using LashRoom.Application.Exceptions;
using LashRoom.Core.Repositories;

namespace LashRoom.Application.Commands.Handlers
{
    public sealed class ChangeServiceExecutionTimeHandler : ICommandHandler<ChangeServiceExecutionTime>
    {
        private IServiceRepository _serviceRepository;

        public ChangeServiceExecutionTimeHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task HandleAsync(ChangeServiceExecutionTime command)
        {
            var serviceToChange = await _serviceRepository.GetAsync(command.serviceId) ?? throw new ServiceNotFoundException(command.serviceId);

            serviceToChange.ModifyExecutionTime(command.executionTime);

            await _serviceRepository.UpdateAsync(serviceToChange);
        }
    }
}
