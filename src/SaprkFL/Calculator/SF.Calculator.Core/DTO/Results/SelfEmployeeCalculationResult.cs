namespace SF.Calculator.Core.DTO.Results
{
    public class SelfEmployeeCalculationResult
    {
        public decimal NetSalary { get; set; }
        public decimal NetSalaryEstimate { get; set; }
        public decimal GrossSalary => TaxBase + VatAmount;
        public decimal IncomeCosts { get; set; }
        public decimal TaxBase { get; set; }
        public decimal VatAmount { get; set; }
        public InsuranceContributionResult InsuranceContribution { get; set; }
    }
}