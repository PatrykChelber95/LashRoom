using LashRoom.Core.Exceptions;

namespace LashRoom.Core.ValueObjects
{
    public sealed record ServiceId
    {
        public Guid Value { get; }

        public ServiceId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static ServiceId Create() => new(Guid.NewGuid());

        public static implicit operator Guid(ServiceId id)
            => id.Value;

        public static implicit operator ServiceId(Guid value)
            => new(value);

        public override string ToString() => Value.ToString("N");
    }
}
