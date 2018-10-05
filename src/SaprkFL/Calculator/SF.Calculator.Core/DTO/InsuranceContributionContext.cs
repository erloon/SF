using SF.Calculator.Core.Model;

namespace SF.Calculator.Core.DTO
{
    public class InsuranceContributionContext
    {
        public decimal InsuranceBaseAmount { get; set; }
        public decimal HealthBaseAmount { get; set; }
        public bool IsMedicalInsurance { get; set; }
        public InsuranceContributionsPercentage Percentage { get; set; }
    }
}