using LashRoom.Application.Abstractions;

namespace LashRoom.Application.Commands
{
    public record AddService(string Name, int Cost, int ExecutionTime) : ICommand
    {
    }
}
