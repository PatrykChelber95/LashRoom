using LashRoom.Core.Entities;
using LashRoom.Core.Repositories;
using LashRoom.Core.ValueObjects;

namespace LashRoom.Infrastructure.DAL.Repositories
{
    internal class InMemoryServiceRepository : IServiceRepository
    {
        private List<Service> _services;

        public InMemoryServiceRepository()
        {
            _services = new List<Service>()
            {
                Service.Create(Guid.Parse("00000000-0000-0000-0000-000000000001"), "Service1", 100, 120),
                Service.Create(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Service2", 150, 130),
                Service.Create(Guid.Parse("00000000-0000-0000-0000-000000000003"), "Service3", 200, 140),
                Service.Create(Guid.Parse("00000000-0000-0000-0000-000000000004"), "Service4", 250, 150),
            };
        }

        public Task<Service> GetAsync(ServiceId id) => Task.FromResult(_services.SingleOrDefault(s => s.Id == id));
        public Task<IEnumerable<Service>> GetAllAsync() => Task.FromResult(_services.AsEnumerable());

        public Task AddAsync(Service service)
        {
            _services.Add(service);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Service service)
        {
            var item = _services.SingleOrDefault(s => s.Id == service.Id);
            if (item != null)
            {
                item = service;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Service service)
        {
            _services.Remove(service);
            return Task.CompletedTask;
        }
    }
}
