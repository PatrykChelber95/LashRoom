namespace LashRoom.Core.ValueObjects
{
    public sealed record ExecutionTime
    {
        public int Value { get; set; }

        public ExecutionTime(int minutes)
        {
            Value = minutes;
        }

        public static implicit operator ExecutionTime(int value) => new(value);
        public static implicit operator int(ExecutionTime value) => value.Value;
    }
}
