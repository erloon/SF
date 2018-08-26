﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SF.Domain.Commands;
using SF.Domain.DTO.Results;
using SF.Domain.Model;
using SF.Infrastructure.CommandHandlerFramework;

namespace SF.API.Controllers
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

            var x = await _mediator.Send(command);
            var retval = _mapper.Map<SelfEmployeeCalculationResult>(x);
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

            var commandResult =  await _mediator.Send(command);
            var retval = _mapper.Map<YearlySelfEmployeeCalculationResult>(commandResult);
            return Ok(retval);
        }
    }
}