using LashRoom.Application.Abstractions;
using LashRoom.Application.Exceptions;
using LashRoom.Core.Repositories;

namespace LashRoom.Application.Commands.Handlers
{
    public sealed class ChangeServiceCostHandler : ICommandHandler<ChangeServiceCost>
    {
        private readonly IServiceRepository _serviceRepository;

        public ChangeServiceCostHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task HandleAsync(ChangeServiceCost command)
        {
            var serviceToChange = await _serviceRepository.GetAsync(command.serviceId) ?? throw new ServiceNotFoundException(command.serviceId);

            serviceToChange.ModifyCost(command.cost);

            await _serviceRepository.UpdateAsync(serviceToChange);
        }
    }
}
