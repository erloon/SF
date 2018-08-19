﻿namespace SF.Domain.DTO.Results
{
    public class MonthlySelfEmployeeCalculationResult
    {
        public decimal NetSalary { get; set; }
        public decimal NetSalaryEstimate { get; set; }
        public decimal GrossSalary => NetSalary + VatAmount;
        public decimal IncomeCosts { get; set; }
        public decimal TaxBase { get; set; }
        public decimal TaxDeductions { get; set; }
        public decimal VatAmount { get; set; }
        public InsuranceContributionResult InsuranceContribution { get; set; }
    }
}