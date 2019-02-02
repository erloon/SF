using SF.Calculator.Core.Commands;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Tests.Factories
{
    public static class SelfEmployeeCalculationCommandFactory
    {
        private const decimal ACIDENTPERCENTAGE = 0.0m;
        private const decimal INCOMECOSTS = 0.0m;
        private const decimal SALARY = 8000m;
        private const decimal VATDEDCUCTIONS = 0m;
        private const TaxationForm TAXIATIONFORM = TaxationForm.GENERAL;

        public static SelfEmployeeCalculationCommand CreateDefault()
        {
            return new SelfEmployeeCalculationCommand()
            {
                AccidentContributionPercentage = ACIDENTPERCENTAGE,
                IncomeCosts = INCOMECOSTS,
                IsGross = false,
                IsMedicalInsurance = false,
                InsuranceContributionForm = InsuranceContributionForm.NORMAL,
                Salary = SALARY,
                TaxationForm = TAXIATIONFORM,
                VatAmmountDeduction = VATDEDCUCTIONS,

            };
        }
    }
}