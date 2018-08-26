using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SF.Domain.Commands;
using SF.Domain.DTO;
using SF.Domain.DTO.Results;
using SF.Domain.Model;
using SF.Domain.Services;
using SF.Domain.TaxCalculators;

namespace SF.Domain.Handlers
{
    public class SelfEmployeeCalculationHandler : IRequestHandler<SelfEmployeeCalculationCommand, SelfEmployeeCalculation>
    {
        private readonly ITaxCalculator _taxCalculator;
        private readonly IInsuranceContributionService _insuranceContributionService;

        public SelfEmployeeCalculationHandler(ITaxCalculator taxCalculator, IInsuranceContributionService insuranceContributionService)
        {
            _taxCalculator = taxCalculator ?? throw new ArgumentNullException(nameof(taxCalculator));
            _insuranceContributionService = insuranceContributionService ?? throw new ArgumentNullException(nameof(insuranceContributionService));
        }
        public async Task<SelfEmployeeCalculation> Handle(SelfEmployeeCalculationCommand request, CancellationToken cancellationToken)
        {
            var context = CreateSelfEmployeeCalculationContext(request);
            SelfEmployeeCalculation calculation = new SelfEmployeeCalculation(context);
            return await Task.FromResult(calculation);
        }

        private SelfEmployeeCalculationContext CreateSelfEmployeeCalculationContext(SelfEmployeeCalculationCommand request)
        {
            //TODO Load insuranceContributionContext from DB
            SelfEmployeeCalculationContext context = new SelfEmployeeCalculationContext()
            {
                BaseAmount = request.Salary,
                IncomeCost = request.IncomeCosts,
                IncomeTaxAmmount = _taxCalculator.Calculate,
                InsuranceContributionContext = request.IsReliefForSocialInsurance ? 
                                               _insuranceContributionService.GetWithDicount(request.AccidentContributionPercentage, request.IsMedicalInsurance) : 
                                               _insuranceContributionService.Get(request.AccidentContributionPercentage, request.IsMedicalInsurance),

                IsMedicalInsurance = request.IsMedicalInsurance,
                Month = (Month)DateTime.Today.Month,
                PreviusMonthsIncome = request.PreviusMonthsIncomes,
                TaxationForm = request.TaxationForm,
                IsGross = request.IsGross
            };

            return context;
        }
    }
}