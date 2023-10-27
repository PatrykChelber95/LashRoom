using LashRoom.Application.Abstractions;

namespace LashRoom.Application.Commands
{
    public record ChangeServiceCost(Guid serviceId, int cost) : ICommand
    { 
    }
}
