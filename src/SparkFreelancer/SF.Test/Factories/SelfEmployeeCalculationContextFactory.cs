using System;
using SF.Domain;
using SF.Domain.DTO;
using SF.Domain.Model;

namespace SF.Test.Factories
{
    public static class SelfEmployeeCalculationContextFactory
    {
        private const decimal BASEAMOUNT = 1000m;
        private const decimal INCOMECOSTAMOUNT = 500m;
        private const decimal TAXAMOUNT = 1326M;

        public static SelfEmployeeCalculationContext Create(TaxationForm taxationForm, Func<TaxCalculationContext, decimal> getIncomeTaxAmmount = null, decimal? baseAmount = null,
            decimal? incomeCost = null, bool? isGross = null, InsuranceContributionContext contributionContext = null)
        {
            return new SelfEmployeeCalculationContext()
            {
                BaseAmount = baseAmount ?? BASEAMOUNT,
                IncomeCost = incomeCost ?? INCOMECOSTAMOUNT,
                IncomeTaxAmmount = getIncomeTaxAmmount ?? new Func<TaxCalculationContext, decimal>((x) => TAXAMOUNT),
                TaxationForm = taxationForm,
                IsGross = isGross ?? false,
                InsuranceContributionContext = contributionContext ?? InsuranceContributionContextFactory.CreateWithPercentage()
            };
        }
    }
}