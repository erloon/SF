using System;
using SF.Domain.Model;

namespace SF.Domain.DTO
{
    public class MonthlySelfEmployeeCalculationContext
    {
        public Month Month { get; set; }
        public decimal BaseAmount { get; set; }
        public decimal VatRate { get; set; }
        public decimal IncomeCost { get; set; }
        public bool IsMedicalInsurance { get; set; }
        public decimal PreviusMonthsIncomes { get; set; }
        public TaxationForm TaxationForm { get; set; }
        public Func<TaxCalculationContext, decimal> IncomeTaxAmmount { get; set; }
        public InsuranceContributionContext InsuranceContributionContext { get; set; }
    }
}