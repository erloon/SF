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

        public SelfEmployeeCalculationHandler(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator ?? throw new ArgumentNullException(nameof(taxCalculator));
        }
        public async Task<SelfEmployeeCalculation> Handle(SelfEmployeeCalculationCommand request, CancellationToken cancellationToken)
        {
            var context = CreateMonthlySelfEmployeeCalculationContext(request);
            SelfEmployeeCalculation calculation = new SelfEmployeeCalculation(context);
            return await Task.FromResult(calculation);
        }

        private MonthlySelfEmployeeCalculationContext CreateMonthlySelfEmployeeCalculationContext(SelfEmployeeCalculationCommand request)
        {
            //TODO Load insuranceContributionContext from DB
            MonthlySelfEmployeeCalculationContext context = new MonthlySelfEmployeeCalculationContext()
            {
                BaseAmount = request.Salary,
                IncomeCost = request.IncomeCosts,
                IncomeTaxAmmount = _taxCalculator.Calculate,
                InsuranceContributionContext = new InsuranceContributionContext()
                {
                    HealthBaseAmount = 3554.93m,
                    InsuranceBaseAmount = 2665.8m,
                    Percentage = new InsuranceContributionsPercentage()
                    {
                        Accident = request.AccidentContributionPercentage,
                        Health = 0.09m,
                        Disabiliti = 0.08m,
                        HealthToDiscount = 0.0775m,
                        LaborFound = 0.0245m,
                        Medical = 0.0245m,
                        Retirement = 0.1952m
                    }
                },
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