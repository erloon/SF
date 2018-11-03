using System;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Core.DTO
{
    public class SelfEmployeeCalculationContext
    {
        public Month Month { get; set; }
        public decimal BaseAmount { get; set; }
        public bool IsGross { get; set; }
        public decimal IncomeCost { get; set; }
        public bool IsMedicalInsurance { get; set; }
        public decimal PreviusMonthsIncome { get; set; }
        public TaxationForm TaxationForm { get; set; }
        public Func<TaxCalculationContext, decimal> IncomeTaxAmmount { get; set; }
        public InsuranceContributionContext InsuranceContributionContext { get; set; }
        public decimal VatTaxRate { get; set; }
        public decimal MonthlyTaxFreeAmount { get; set; }
    }
}