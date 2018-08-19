namespace SF.Domain.Model
{
    public class InsuranceContributionsPercentage
    {
        public decimal Accident { get;  set; }
        public decimal Health { get;  set; }
        public decimal Retirement { get;  set; }
        public decimal HealthToDiscount { get;  set; }
        public decimal Disabiliti { get;  set; }
        public decimal Medical { get;  set; }
        public decimal LaborFound { get;  set; }

        public InsuranceContributionsPercentage()
        {
            
        }
    }
}