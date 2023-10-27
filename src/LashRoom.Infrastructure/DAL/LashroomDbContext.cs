using LashRoom.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LashRoom.Infrastructure.DAL
{
    internal sealed class LashroomDbContext : DbContext
    {
        public DbSet<Service> Services { get; set; }

        public LashroomDbContext(DbContextOptions<LashroomDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
