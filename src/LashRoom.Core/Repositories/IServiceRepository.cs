using LashRoom.Core.Entities;
using LashRoom.Core.ValueObjects;

namespace LashRoom.Core.Repositories
{
    public interface IServiceRepository
    {
        Task<Service> GetAsync(ServiceId id);
        Task<IEnumerable<Service>> GetAllAsync();
        Task AddAsync(Service service);
        Task UpdateAsync(Service service);
        Task DeleteAsync(Service service);
    }
}
