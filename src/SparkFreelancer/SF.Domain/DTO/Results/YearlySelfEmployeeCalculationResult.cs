using System.Collections.Generic;

namespace SF.Domain.DTO.Results
{
    public class YearlySelfEmployeeCalculationResult
    {
        public decimal NetSalarySum { get; set; }
        public decimal TaxesSum { get; set; }
        public List<MonthlySelfEmployeeCalculationResult> MonthlyResults { get; set; }
    }
}