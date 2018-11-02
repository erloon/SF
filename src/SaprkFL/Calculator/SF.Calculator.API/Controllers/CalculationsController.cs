using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SF.Calculator.Core.Commands;
using SF.Calculator.Core.DTO.Results;

namespace SF.Calculator.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CalculationsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> SelfEmployeeCalculation([FromBody]SelfEmployeeCalculationCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commandResult = await _mediator.Send(command);
            var retval = _mapper.Map<SelfEmployeeCalculationResult>(commandResult);
            return Ok(retval);
        }

        [HttpPost]
        public async Task<IActionResult> YearlySelfEmployeeCalculation(
            [FromBody] YearlySelfEmployeeCalculationCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commandResult = await _mediator.Send(command);
            YearlySelfEmployeeCalculationResult retval;

            retval = _mapper.Map<YearlySelfEmployeeCalculationResult>(commandResult);

            return Ok(retval);
        }
    }
}