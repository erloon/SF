using MediatR;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Core.Commands
{
    public class SelfEmployeeCalculationCommand : IRequest<SelfEmployeeCalculation>
    {
        public decimal Salary { get; set; }
        public bool IsGross { get; set; }
        public decimal VatAmountDeduction { get; set; }
        public decimal IncomeCosts { get; set; }
        public decimal AccidentContributionPercentage { get; set; }
        public bool IsMedicalInsurance { get; set; }
        public InsuranceContributionForm InsuranceContributionForm { get; set; }
        public decimal PreviousMonthsIncomes { get; set; }
        public TaxationForm TaxationForm { get; set; }
    }
}