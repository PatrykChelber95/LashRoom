using LashRoom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LashRoom.Infrastructure.DAL
{
    internal sealed class DatabaseInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DatabaseInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LashroomDbContext>();
                dbContext.Database.Migrate();

                var services = dbContext.Services.ToList();

                if (services.Any())
                {
                    return Task.CompletedTask;
                }

                services = new List<Service>()
                {
                    Service.Create(Guid.Parse("00000000-0000-0000-0000-000000000001"), "Service1", 100, 120),
                    Service.Create(Guid.Parse("00000000-0000-0000-0000-000000000002"), "Service2", 150, 130),
                    Service.Create(Guid.Parse("00000000-0000-0000-0000-000000000003"), "Service3", 200, 140),
                    Service.Create(Guid.Parse("00000000-0000-0000-0000-000000000004"), "Service4", 250, 150),
                };

                dbContext.Services.AddRange(services);
                dbContext.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
