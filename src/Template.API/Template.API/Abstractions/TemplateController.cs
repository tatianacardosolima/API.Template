using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Template.API.Controllers;
using Template.Domain.Entities;
using Template.Domain.Interface.Request;

namespace Template.API.Abstractions
{
    public abstract class TemplateController<TNewRequest, TUpdRequest, TFilterRequest, TDelRequest>
                    : Controller where TNewRequest : ICommandRequest
                                 where TUpdRequest : IUniqueIdCommandRequest
                                 where TFilterRequest : IUniqueIdCommandRequest
                                 where TDelRequest : IUniqueIdCommandRequest
    {
        private readonly IMediator _mediator;

        public TemplateController(IMediator mediator)
        {            
            _mediator = mediator;
        }

        [HttpPost/*, Authorize*/]
        public virtual async Task<IActionResult> InsertAsync(TNewRequest request)
        {
            var result = await _mediator.Send(request);
            return StatusCode(201, result);
        }

        [HttpPut("{uniqueId}")/*, Authorize*/]
        public async Task<IActionResult> UpdateAsync(TUpdRequest request, Guid uniqueId)
        {
            request.UniqueId = uniqueId;
            var result = await _mediator.Send(request);
            return StatusCode(200, result);
        }

        //[HttpDelete("{id}"), /*Authorize*/]
        //public async Task<IActionResult> DeleteAsync(Guid id)
        //{

        //    TDelRequest.UniqueId = id;
        //    var result = await _mediator.Send(request);
        //    return StatusCode(200, result);
        //}

        //[HttpGet("{id}"), /*Authorize*/]
        //public async Task<IActionResult> GetByIdAsync(Guid id)
        //{
        //    return Ok(await _service.GetByIdAsync(id));
        //}
    }
}
