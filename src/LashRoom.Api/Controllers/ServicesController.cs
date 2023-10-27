using LashRoom.Application.Abstractions;
using LashRoom.Application.Commands;
using LashRoom.Application.DTO;
using LashRoom.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LashRoom.Api.Controllers
{
    [ApiController]
    [Route(template: "services")]
    public class ServicesController : ControllerBase
    {
        private readonly ICommandHandler<AddService> _addServiceHandler;
        private readonly ICommandHandler<ChangeServiceCost> _changeServiceCostHandler;
        private readonly ICommandHandler<ChangeServiceExecutionTime> _changeServiceExecutionTimeHandler;
        private readonly IQueryHandler<GetServices, IEnumerable<ServiceDto>> _getServicesHandler;

        public ServicesController(ICommandHandler<AddService> addServiceHandler,
            ICommandHandler<ChangeServiceCost> changeServiceCostHandler,
            ICommandHandler<ChangeServiceExecutionTime> changeServiceExecutionTimeHandler,
            IQueryHandler<GetServices, IEnumerable<ServiceDto>> getServicesHandler)
        {
            _addServiceHandler = addServiceHandler;
            _changeServiceCostHandler = changeServiceCostHandler;
            _changeServiceExecutionTimeHandler = changeServiceExecutionTimeHandler;

            _getServicesHandler = getServicesHandler;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceDto>> Get([FromQuery] GetServices query)
            => Ok(await _getServicesHandler.HandleAsync(query));

        [HttpPost]
        public async Task<ActionResult> Post(AddService command)
        {
            await _addServiceHandler.HandleAsync(command);

            return NoContent();
        }

        [HttpPut("cost/{serviceId:guid}")]
        public async Task<ActionResult> Put(Guid serviceId, ChangeServiceCost command)
        {
            await _changeServiceCostHandler.HandleAsync(command with { serviceId = serviceId });
            return NoContent();  
        }

        [HttpPut("executiontime/{serviceId:guid}")]
        public async Task<ActionResult> Put(Guid serviceId, ChangeServiceExecutionTime command)
        {
            await _changeServiceExecutionTimeHandler.HandleAsync(command with { serviceId = serviceId });
            return NoContent();
        }
    }
}
