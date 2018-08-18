using System;
using SF.Domain;
using SF.Domain.DTO;

namespace SF.Test.Factories
{
    public static class MonthlySelfEmployeeCalculationContextFactory
    {
        private const decimal BASEAMOUNT = 1000m;
        private const decimal VATRATE = 0.23m;
        private const decimal INCOMECOSTAMOUNT = 500m;

        public static MonthlySelfEmployeeCalculationContext Create(TaxationForm taxationForm, Func<TaxationForm, decimal, decimal> getIncomTaxRate, decimal? baseAmount = null, decimal? vatRate = null, decimal? incomeCost = null, InsuranceContributionContext contributionContext = null)
        {
            return new MonthlySelfEmployeeCalculationContext()
            {
                BaseAmount = baseAmount ?? BASEAMOUNT,
                IncomeCost = incomeCost ?? INCOMECOSTAMOUNT,
                VatRate = vatRate ?? VATRATE,
                TaxationForm = taxationForm,
                GetIncomTaxRate = getIncomTaxRate,
                InsuranceContributionContext = contributionContext ?? InsuranceContributionContextFactory.CreateWithPercentage()
            };
        }
    }
}