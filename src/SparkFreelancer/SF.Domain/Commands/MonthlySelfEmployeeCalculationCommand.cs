using SF.Infrastructure;
using SF.Infrastructure.CommandHandlerFramework;

namespace SF.Domain.Commands
{
    public class MonthlySelfEmployeeCalculationCommand : ICommand
    {
        public decimal Salary { get; set; }
        public bool IsGross { get; set; }
        public decimal VatAmmountDeduction { get; set; }
        public decimal IncomeCosts { get; set; }
        public decimal AccidentContributionPercentage { get; set; }
        public bool IsMedicalInsurance { get; set; }
        public bool IsReliefForSocialInsurance { get; set; }
        public TaxationForm TaxationForm { get; set; }
        public CalculationType CalculationType { get; set; }
    }
}