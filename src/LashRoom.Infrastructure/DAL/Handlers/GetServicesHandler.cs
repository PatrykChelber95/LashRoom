using LashRoom.Application.Abstractions;
using LashRoom.Application.DTO;
using LashRoom.Application.Queries;
using Microsoft.EntityFrameworkCore;

namespace LashRoom.Infrastructure.DAL.Handlers
{
    internal sealed class GetServicesHandler : IQueryHandler<GetServices, IEnumerable<ServiceDto>>
    {
        private readonly LashroomDbContext _dbContext;

        public GetServicesHandler(LashroomDbContext dbContext) => _dbContext = dbContext;
        public async Task<IEnumerable<ServiceDto>> HandleAsync(GetServices query)
        {
            var services = await _dbContext.Services
                .AsNoTracking()
                .ToListAsync();

            return services.Select(x => x.AsDto());
        }
    }
}
