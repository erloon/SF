using System;
using System.Collections.Generic;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Core.DTO
{
    public class YearlySelfEmployeeCalculationContext
    {
        public bool IsGross { get; set; }
        public decimal AccidentContributionPercentage { get; set; }
        public bool IsMedicalInsurance { get; set; }
        public bool IsReliefForSocialInsurance { get; set; }
        public TaxationForm TaxationForm { get; set; }
        public InsuranceContributionContext InsuranceContributionContext { get; set; }
        public Func<TaxCalculationContext, decimal> IncomeTaxAmmount { get; set; }
        public List<MonthlyBalanceSheetData> MonthlyBalanceSheetDatas { get; set; }
    }
}