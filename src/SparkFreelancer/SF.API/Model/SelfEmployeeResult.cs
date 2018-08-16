﻿namespace SF.API.Model
{
    public class SelfEmployeeResult
    {
        public decimal NetSalary { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal IncomeCosts { get; set; }
        public decimal TaxBase { get; set; }
        public decimal TaxDeductions { get; set; }
        public decimal VatAmount { get; set; }
        public InsuranceContributionResult InsuranceContribution { get; set; }
    }
}