using SF.Domain.Model;

namespace SF.Domain.DTO
{
    public class InsuranceContributionContext
    {
        public decimal InsuranceBaseAmount { get; set; }
        public decimal HealthBaseAmount { get; set; }
        public bool IsMedicalInsurance { get; set; }
        public InsuranceContributionsPercentage Percentage { get; set; }
    }
}