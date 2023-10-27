namespace LashRoom.Core.Exceptions
{
    public sealed class InvalidCostException : CustomException
    {
        public int Cost { get; set; }
        public InvalidCostException(int cost) 
            : base($"Cost {cost} is invalid")
        {
            Cost = cost;
        }
    }
}
