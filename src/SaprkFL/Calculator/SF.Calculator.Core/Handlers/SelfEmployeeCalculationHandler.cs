using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SF.Calculator.Core.Commands;
using SF.Calculator.Core.DTO;
using SF.Calculator.Core.Model;
using SF.Calculator.Core.Repositories;
using SF.Calculator.Core.Services;
using SF.Calculator.Core.TaxCalculators;

namespace SF.Calculator.Core.Handlers
{
    public class SelfEmployeeCalculationHandler : IRequestHandler<SelfEmployeeCalculationCommand, SelfEmployeeCalculation>
    {
        private readonly ITaxCalculator _taxCalculator;
        private readonly IInsuranceContributionService _insuranceContributionService;
        private readonly IBaseValuesDictionaryRepository _baseValuesDictionaryRepository;
        private const string VATKEY = "VATTaxRate";
        private const string MONTHLYTAXFREEAMOUNTKEY = "MonthlyTaxFreeAmount";
        public SelfEmployeeCalculationHandler(ITaxCalculator taxCalculator, IInsuranceContributionService insuranceContributionService,IBaseValuesDictionaryRepository baseValuesDictionaryRepository)
        {
            _taxCalculator = taxCalculator ?? throw new ArgumentNullException(nameof(taxCalculator));
            _insuranceContributionService = insuranceContributionService ?? throw new ArgumentNullException(nameof(insuranceContributionService));
            _baseValuesDictionaryRepository = baseValuesDictionaryRepository ?? throw new ArgumentNullException(nameof(baseValuesDictionaryRepository));
        }
        public async Task<SelfEmployeeCalculation> Handle(SelfEmployeeCalculationCommand request, CancellationToken cancellationToken)
        {
            var context = CreateSelfEmployeeCalculationContext(request);
            SelfEmployeeCalculation calculation = new SelfEmployeeCalculation(context);



            return await Task.FromResult(calculation);
        }

        private SelfEmployeeCalculationContext CreateSelfEmployeeCalculationContext(SelfEmployeeCalculationCommand request)
        {

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
                IsGross = request.IsGross,
                VatTaxRate = GetValue(VATKEY),
                MonthlyTaxFreeAmount = GetValue(MONTHLYTAXFREEAMOUNTKEY)
             
            };

            return context;
        }

        
        private decimal GetValue(string key)
        {
            var retval = _baseValuesDictionaryRepository.Get(key);

            if (!decimal.TryParse(retval.Value, out var value)) throw new ArgumentException();

            return value;
        }
    }
}