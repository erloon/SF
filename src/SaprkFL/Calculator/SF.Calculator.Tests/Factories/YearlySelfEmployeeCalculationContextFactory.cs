﻿using System.Collections.Generic;
using SF.Calculator.Core.DTO;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Tests.Factories
{
    public static class YearlySelfEmployeeCalculationContextFactory
    {
        private static Dictionary<Month, decimal> COSTS = new Dictionary<Month, decimal>()
        {
            {Month.JANUARY,1000m },
            {Month.FEBRUARY,1000m },
            {Month.MARCH,1000m },
            {Month.APRIL,1000m },
            {Month.MAY,1000m },
            {Month.JUNE,1000m },
            {Month.JULY,1000m },
            {Month.AUGUST,1000m },
            {Month.SEPTEMBER,1000m },
            {Month.OCTOBER,1000m },
            {Month.NOVEMBER,1000m },
            {Month.DECEMBER,1000m }
        };

        private static Dictionary<Month, decimal> INCOMES = new Dictionary<Month, decimal>()
        {
            {Month.JANUARY,8000m },
            {Month.FEBRUARY,8000m },
            {Month.MARCH,8000m },
            {Month.APRIL,8000m },
            {Month.MAY,8000m },
            {Month.JUNE,8000m },
            {Month.JULY,8000m },
            {Month.AUGUST,8000m },
            {Month.SEPTEMBER,8000m },
            {Month.OCTOBER,8000m },
            {Month.NOVEMBER,8000m },
            {Month.DECEMBER,8000m }
        };

        //private static decimal VAT = 0.23m;

        public static YearlySelfEmployeeCalculationContext Create(TaxationForm taxation, bool isMedicalInsurance = false,
            Dictionary<Month, decimal> costs = null,
            Dictionary<Month, decimal> incomes = null,
            InsuranceContributionContext insuranceContributionContext = null)
        {
            return new YearlySelfEmployeeCalculationContext()
            {
                //VatRate = VAT,
                //Costs = costs ?? COSTS,
                //Incomes = incomes ?? INCOMES,
                //InsuranceContributionContext = insuranceContributionContext ?? InsuranceContributionContextFactory.CreateWithPercentage(),
                //IsMedicalInsurance = isMedicalInsurance
            };
        }
    }
}