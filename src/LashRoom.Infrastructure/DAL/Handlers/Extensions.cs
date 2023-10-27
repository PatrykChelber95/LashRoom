using LashRoom.Application.DTO;
using LashRoom.Core.Entities;

namespace LashRoom.Infrastructure.DAL.Handlers
{
    internal static class Extensions
    {
        public static ServiceDto AsDto(this Service entity)
            => new()
            {
                Id = entity.Id.Value.ToString(),
                Name = entity.Name,
                Cost = entity.Cost,
                ExecutionTime = entity.ExecutionTime
            };
    }
}
