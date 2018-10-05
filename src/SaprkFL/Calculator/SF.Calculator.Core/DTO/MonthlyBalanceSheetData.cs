using SF.Calculator.Core.Model;

namespace SF.Calculator.Core.DTO
{
    public class MonthlyBalanceSheetData
    {
        public Month Month { get; set; }
        public decimal Salary { get; set; }
        public decimal IncomeCosts { get; set; }
    }
}