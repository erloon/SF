using System.Threading.Tasks;
using SF.Domain.Commands;
using SF.Infrastructure.CommandHandlerFramework;

namespace SF.Domain.Handlers
{
    public class MonthlySelfEmployeeCalculationHandler : ICommandHandler<MonthlySelfEmployeeCalculationCommand>
    {
        public async Task ExecuteAsync(MonthlySelfEmployeeCalculationCommand command)
        {
            var t = command;
        }
    }
}