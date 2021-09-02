using LightweightArchitectureWebApi.Commands.GetOrderCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightweightArchitectureWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetOrderCommand { OrderId = id });
            return Ok(response);
        }

        // not restful
        // demo of request model validation

        [HttpPost("get-by-id")]
        public async Task<IActionResult> GetById(GetOrderCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
