﻿using SF.Domain.DTO;

namespace SF.Tests.Factories
{
    public class SelfEmployeeCalculationContextFactory
    {
        private const decimal BASEAMOUNT = 1000m;
        private const decimal VATRATE = 0.23m;
        private const decimal INCOMECOSTAMOUNT = 500m;

        public static SelfEmployeeCalculationContext Create(decimal? baseAmount = null, decimal? vatRate = null, decimal? incomeCost = null, InsuranceContributionContext contributionContext = null)
        {
            return new SelfEmployeeCalculationContext()
            {
                BaseAmount = baseAmount ?? BASEAMOUNT,
                IncomeCost = incomeCost ?? INCOMECOSTAMOUNT,
                VatRate = vatRate ?? VATRATE,
                InsuranceContributionContext = contributionContext ?? InsuranceContributionContextFactory.Create()
            };
        }
    }
}