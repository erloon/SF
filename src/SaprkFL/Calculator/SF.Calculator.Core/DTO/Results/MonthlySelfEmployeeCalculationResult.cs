using SF.Calculator.Core.Model;

namespace SF.Calculator.Core.DTO.Results
{
    public class MonthlySelfEmployeeCalculationResult
    {
        public Month Month { get; set; }
        public SelfEmployeeCalculationResult Result { get; set; }
    }
}