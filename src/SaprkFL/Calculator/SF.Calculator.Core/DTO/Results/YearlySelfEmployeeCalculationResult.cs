using System.Collections.Generic;

namespace SF.Calculator.Core.DTO.Results
{
    public class YearlySelfEmployeeCalculationResult
    {
        public decimal NetSalarySum { get; set; }
        public decimal IncomeCostsSum { get; set; }
        public List<MonthlySelfEmployeeCalculationResult> MonthlyResults { get; set; }
    }
}