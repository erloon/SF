using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SF.Domain.Commands;
using SF.Domain.DTO.Results;

namespace SF.Domain.Handlers
{
    public class SelfEmployeeCalculationHandler : IRequestHandler<MonthlySelfEmployeeCalculationCommand,MonthlySelfEmployeeCalculationResult>
    {
        public Task<MonthlySelfEmployeeCalculationResult> Handle(MonthlySelfEmployeeCalculationCommand request, CancellationToken cancellationToken)
        {
            return new Task<MonthlySelfEmployeeCalculationResult>(()=> {return new MonthlySelfEmployeeCalculationResult();});
        }
    }
}