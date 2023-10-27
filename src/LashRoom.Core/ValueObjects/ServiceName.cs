using LashRoom.Core.Exceptions;

namespace LashRoom.Core.ValueObjects
{
    public sealed record ServiceName(string Value)
    {
        public string Value { get; } = Value ?? throw new InvalidServiceNameException(Value);

        public static implicit operator ServiceName(string value) 
            => new(value);
        public static implicit operator string(ServiceName name) 
            => name.Value;
    }
}
