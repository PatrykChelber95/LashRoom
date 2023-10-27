using LashRoom.Application.Abstractions;
using LashRoom.Application.DTO;

namespace LashRoom.Application.Queries
{
    public sealed class GetServices : IQuery<IEnumerable<ServiceDto>>
    {
    }
}
