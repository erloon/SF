﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SF.Domain.Commands;
using SF.Domain.DTO;
using SF.Domain.DTO.Results;
using SF.Domain.Model;
using SF.Domain.Services;
using SF.Domain.TaxCalculators;

namespace SF.Domain.Handlers
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
            var calcualtion = new YearlySelfEmployeeCalculation(context);
            return Task.FromResult<YearlySelfEmployeeCalculation>(calcualtion);
        }

        private YearlySelfEmployeeCalculationContext CreateContext(YearlySelfEmployeeCalculationCommand request)
        {
            return new YearlySelfEmployeeCalculationContext()
            {
                AccidentContributionPercentage = request.AccidentContributionPercentage,
                IncomeTaxAmmount = _taxCalculator.Calculate,
                InsuranceContributionContext = request.IsReliefForSocialInsurance ?
                                                        _insuranceContributionService.GetWithDicount(request.AccidentContributionPercentage, request.IsMedicalInsurance) :
                                                        _insuranceContributionService.Get(request.AccidentContributionPercentage, request.IsMedicalInsurance),
                IsGross = request.IsGross,
                IsMedicalInsurance = request.IsMedicalInsurance,
                IsReliefForSocialInsurance = request.IsReliefForSocialInsurance,
                MonthlyBalanceSheetDatas = request.MonthlyBalanceSheetDatas,
                TaxationForm = request.TaxationForm
            };
        }
    }
}