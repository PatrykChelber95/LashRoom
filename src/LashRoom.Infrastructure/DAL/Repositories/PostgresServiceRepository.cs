using LashRoom.Core.Entities;
using LashRoom.Core.Repositories;
using LashRoom.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LashRoom.Infrastructure.DAL.Repositories
{
    internal sealed class PostgresServiceRepository : IServiceRepository
    {
        private readonly LashroomDbContext _dbContext;

        public PostgresServiceRepository(LashroomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Service> GetAsync(ServiceId id) => _dbContext.Services.SingleOrDefaultAsync(service => service.Id == id);
        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            var result = await _dbContext.Services.ToListAsync();
            return result.AsEnumerable();
        }
        public async Task AddAsync(Service service)
        {
            await _dbContext.AddAsync(service);
        }

        public async Task DeleteAsync(Service service)
        {
            _dbContext.Remove(service);
            await _dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Service service)
        {
            _dbContext.Services.Update(service);
            return Task.CompletedTask;
        }
    }
}
