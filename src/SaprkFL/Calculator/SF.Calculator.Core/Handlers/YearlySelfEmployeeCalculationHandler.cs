using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SF.Calculator.Core.Commands;
using SF.Calculator.Core.DTO;
using SF.Calculator.Core.Model;
using SF.Calculator.Core.Services;
using SF.Calculator.Core.TaxCalculators;

namespace SF.Calculator.Core.Handlers
{
    public class YearlySelfEmployeeCalculationHandler : IRequestHandler<YearlySelfEmployeeCalculationCommand, YearlySelfEmployeeCalculation>
    {
        private readonly ITaxCalculator _taxCalculator;
        private readonly IInsuranceContributionService _insuranceContributionService;

        public YearlySelfEmployeeCalculationHandler(ITaxCalculator taxCalculator, IInsuranceContributionService insuranceContributionService)
        {
            _taxCalculator = taxCalculator ?? throw new ArgumentNullException(nameof(taxCalculator));
            _insuranceContributionService = insuranceContributionService ?? throw new ArgumentNullException(nameof(insuranceContributionService));
        }

        public Task<YearlySelfEmployeeCalculation> Handle(YearlySelfEmployeeCalculationCommand request, CancellationToken cancellationToken)
        {
            var context = CreateContext(request);
            var calculation = new YearlySelfEmployeeCalculation(context);
            return Task.FromResult<YearlySelfEmployeeCalculation>(calculation);
        }

        private YearlySelfEmployeeCalculationContext CreateContext(YearlySelfEmployeeCalculationCommand request)
        {
            return new YearlySelfEmployeeCalculationContext()
            {
                AccidentContributionPercentage = request.AccidentContributionPercentage,
                IncomeTaxAmount = _taxCalculator.Calculate,
                InsuranceContributionContext = _insuranceContributionService.Create(request.InsuranceContributionForm,request.AccidentContributionPercentage, request.IsMedicalInsurance),
                IsGross = request.IsGross,
                IsMedicalInsurance = request.IsMedicalInsurance,
                MonthlyBalanceSheetData = request.MonthlyBalanceSheetData,
                TaxationForm = request.TaxationForm
            };
        }
    }
}