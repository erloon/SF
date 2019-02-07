using System.Collections.Generic;
using MediatR;
using SF.Calculator.Core.DTO;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Core.Commands
{
    public class YearlySelfEmployeeCalculationCommand : IRequest<YearlySelfEmployeeCalculation>
    {
        public bool IsGross { get; set; }
        public decimal AccidentContributionPercentage { get; set; }
        public bool IsMedicalInsurance { get; set; }
        public InsuranceContributionForm InsuranceContributionForm { get; set; }
        public TaxationForm TaxationForm { get; set; }

        public List<MonthlyBalanceSheetData> MonthlyBalanceSheetData { get; set; }


    }

}