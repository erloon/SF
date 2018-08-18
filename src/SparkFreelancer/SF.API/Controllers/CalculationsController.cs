using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SF.Domain.Commands;
using SF.Infrastructure.CommandHandlerFramework;

namespace SF.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CalculationsController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher ?? throw new ArgumentNullException(nameof(commandDispatcher));
        }

        [HttpPost]
        public async Task<ActionResult> MonthlySelfEmployeeCalculation(MonthlySelfEmployeeCalculationCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return new AcceptedResult();
        }
    }
}