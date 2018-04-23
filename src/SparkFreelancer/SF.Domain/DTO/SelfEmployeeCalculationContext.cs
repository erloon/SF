using System;

namespace SF.Domain.DTO
{
    public class SelfEmployeeCalculationContext
    {
        public decimal BaseAmount { get; set; }
        public decimal VatRate { get; set; }
        public decimal IncomeCost { get; set; }
        public bool IsMedicalInsurance { get; set; }
        public decimal PreviusMonthsIncomes { get; set; }
        public TaxationForm TaxationForm { get; set; }
        public Func<TaxationForm, decimal, decimal> GetIncomTaxRate { get; set; }
        public InsuranceContributionContext InsuranceContributionContext { get; set; }
    }
}