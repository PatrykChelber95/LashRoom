namespace LashRoom.Core.Exceptions
{
    public sealed class InvalidServiceNameException : CustomException
    {
        public InvalidServiceNameException(string serviceName) 
            : base($"Service name: {serviceName} is invalid")
        {
        }
    }
}
