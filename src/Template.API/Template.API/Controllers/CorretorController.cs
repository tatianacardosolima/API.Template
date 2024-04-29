using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Domain.Commands.Request;

namespace Template.API.Controllers
{
    [ApiController]
    [Route("corretores")]
    public class CorretorController : ControllerBase
    {
        private readonly ILogger<CorretorController> _logger;
        private readonly IMediator _mediator;

        public CorretorController(ILogger<CorretorController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] NewCorretorRequest corretor)
        {
            var result = await _mediator.Send(corretor);
            return StatusCode(201, result);

        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdCorretorRequest corretor)
        {
            var result = await _mediator.Send(corretor);
            return StatusCode(200, result);

        }
        [HttpGet("{uniqueId}")]
        public async Task<ActionResult> GetByUniqueId(Guid uniqueId)
        {
            var result = await _mediator.Send(new CorretorByUniqueId(uniqueId));
            return StatusCode(200, result);

        }

        [HttpDelete("{uniqueId}")]
        public async Task<ActionResult> DeleteByUniqueId(Guid uniqueId)
        {
            var result = await _mediator.Send(new DelCorretorRequest(uniqueId));
            return StatusCode(200, result);

        }
    }
}
