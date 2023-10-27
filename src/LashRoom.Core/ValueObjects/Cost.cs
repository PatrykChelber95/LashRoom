using LashRoom.Core.Exceptions;

namespace LashRoom.Core.ValueObjects
{
    public sealed record Cost
    {
        public int Value { get; set; }

        public Cost(int value)
        {
            if (value is < 0)
            {
                throw new InvalidCostException(value);
            }

            Value = value;
        }

        public static implicit operator Cost(int value) => new(value);
        public static implicit operator int(Cost value) => value.Value;
    }
}
