using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SF.Domain.Commands;
using SF.Domain.DTO;
using SF.Domain.DTO.Results;
using SF.Domain.Services;

namespace SF.Domain.Handlers
{
    public class SelfEmployeeCalculationHandler : IRequestHandler<MonthlySelfEmployeeCalculationCommand,MonthlySelfEmployeeCalculationResult>
    {
        private readonly ITaxPercentagesService _taxPercentagesService;

        public SelfEmployeeCalculationHandler(ITaxPercentagesService taxPercentagesService)
        {
            _taxPercentagesService = taxPercentagesService ?? throw new ArgumentNullException(nameof(taxPercentagesService));
        }
        public async Task<MonthlySelfEmployeeCalculationResult> Handle(MonthlySelfEmployeeCalculationCommand request, CancellationToken cancellationToken)
        {
            MonthlySelfEmployeeCalculationContext context = new MonthlySelfEmployeeCalculationContext();
            MonthlySelfEmployeeCalculation calculation = new MonthlySelfEmployeeCalculation(new MonthlySelfEmployeeCalculationContext());
            return await Task.FromResult(result);
        }
    }
}