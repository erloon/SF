using SF.Domain.Model;

namespace SF.Domain.DTO.Results
{
    public class MonthlySelfEmployeeCalculationResult
    {
        public Month Month { get; set; }
        public SelfEmployeeCalculationResult Result { get; set; }
    }
}