using LashRoom.Core.Exceptions;

namespace LashRoom.Application.Exceptions
{
    public sealed class ServiceNotFoundException : CustomException
    {
        public Guid? Id { get; }
        public ServiceNotFoundException(Guid id) 
            : base($"Service with ID: {id} was not found")
        {
            Id = id;
        }

        public ServiceNotFoundException()
            : base($"Service with ID was not found")
        {
            
        }
    }
}
