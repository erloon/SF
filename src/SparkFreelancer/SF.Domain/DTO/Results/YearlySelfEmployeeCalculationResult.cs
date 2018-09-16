using System.Collections.Generic;

namespace SF.Domain.DTO.Results
{
    public class YearlySelfEmployeeCalculationResult
    {
        public decimal NetSalarySum { get; set; }
        public decimal IncomeCostsSum { get; set; }
        public List<MonthlySelfEmployeeCalculationResult> MonthlyResults { get; set; }
    }
}