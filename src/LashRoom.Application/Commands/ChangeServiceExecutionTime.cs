using LashRoom.Application.Abstractions;

namespace LashRoom.Application.Commands
{
    public record ChangeServiceExecutionTime(Guid serviceId, int executionTime) : ICommand
    {
    }
}
