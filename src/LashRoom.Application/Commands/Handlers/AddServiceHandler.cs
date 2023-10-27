using LashRoom.Application.Abstractions;
using LashRoom.Core.Entities;
using LashRoom.Core.Repositories;

namespace LashRoom.Application.Commands.Handlers
{
    public sealed class AddServiceHandler : ICommandHandler<AddService>
    {
        private readonly IServiceRepository _serviceRepository;

        public AddServiceHandler(IServiceRepository serviceRepository)
        {
                _serviceRepository = serviceRepository;
        }

        public async Task HandleAsync(AddService command)
        {
            var newService = new Service(Guid.NewGuid(), command.Name, command.Cost, command.ExecutionTime);

            await _serviceRepository.AddAsync(newService);
        }
    }
}
