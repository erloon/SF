using SF.Domain.Model;

namespace SF.Domain.DTO
{
    public class MonthlyBalanceSheetData
    {
        public Month Month { get; set; }
        public decimal Salary { get; set; }
        public decimal IncomeCosts { get; set; }
    }
}