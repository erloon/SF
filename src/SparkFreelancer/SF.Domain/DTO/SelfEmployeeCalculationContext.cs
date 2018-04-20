namespace SF.Domain.DTO
{
    public class SelfEmployeeCalculationContext
    {
        public decimal BaseAmount { get; set; }
        public decimal VatRate { get; set; }
        public decimal IncomeCost { get; set; }
        public InsuranceContributionContext InsuranceContributionContext { get; set; }
    }
}