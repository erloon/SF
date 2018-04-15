namespace SF.Domain
{
    public class InsuranceContributionsPercentage
    {
        public decimal Accident { get; protected set; }
        public decimal Health { get; protected set; }
        public decimal Retirement { get; protected set; }
        public decimal HealthToDiscount { get; protected set; }
        public decimal Disabiliti { get; protected set; }
        public decimal Medical { get; protected set; }
        public decimal LaborFound { get; protected set; }
    }
}