using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SF.Domain.Commands;
using SF.Domain.DTO.Results;
using SF.Infrastructure.CommandHandlerFramework;

namespace SF.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalculationsController(IMediator mediator)
        {
           //_commandDispatcher = commandDispatcher ?? throw new ArgumentNullException(nameof(commandDispatcher));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ActionResult<MonthlySelfEmployeeCalculationResult>> MonthlySelfEmployeeCalculation()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            MonthlySelfEmployeeCalculationCommand command = new MonthlySelfEmployeeCalculationCommand();
            return await _mediator.Send(command);
        }
    }
}