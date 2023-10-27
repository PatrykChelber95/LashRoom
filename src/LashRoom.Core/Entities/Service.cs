using LashRoom.Core.ValueObjects;

namespace LashRoom.Core.Entities
{
    public class Service
    {
        public ServiceId Id { get; private set; }
        public ServiceName Name { get; private set; }
        public Cost Cost { get; private set; }
        public ExecutionTime ExecutionTime { get; private set; }

        public Service(ServiceId id, ServiceName name, Cost cost, ExecutionTime executionTime)
        {
            Id = id;
            Name = name;
            Cost = cost;
            ExecutionTime = executionTime;
        }

        public static Service Create(ServiceId id, ServiceName name, Cost cost, ExecutionTime executionTime)
            => new(id, name, cost, executionTime);

        public void ModifyCost(Cost cost) => Cost = cost;
        public void ModifyExecutionTime(ExecutionTime time) => ExecutionTime = time;
    }
}
