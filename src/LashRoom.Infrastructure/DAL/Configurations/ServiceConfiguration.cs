using LashRoom.Core.Entities;
using LashRoom.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LashRoom.Infrastructure.DAL.Configurations
{
    internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new ServiceId(x));
            builder.Property(x => x.Name)
                .HasConversion(x => x.Value, x => new ServiceName(x));
            builder.Property(x => x.Cost)
                .HasConversion(x => x.Value, x => new Cost(x));
            builder.Property(x => x.ExecutionTime)
                .HasConversion(x => x.Value, x => new ExecutionTime(x));
        }
    }
}
