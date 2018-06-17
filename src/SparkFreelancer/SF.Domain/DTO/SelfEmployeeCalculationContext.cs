using System.Collections.Generic;

namespace SF.Domain.DTO
{
    public class SelfEmployeeCalculationContext
    {
        public decimal VatRate { get; set; }
        public Dictionary<Month, decimal> Costs { get; set; }
        public Dictionary<Month, decimal> Incomes { get; set; }
        public TaxationForm TaxationForm { get; set; }
        public InsuranceContributionContext InsuranceContributionContext { get; set; }
        public bool IsMedicalInsurance { get; set; }
    }
}