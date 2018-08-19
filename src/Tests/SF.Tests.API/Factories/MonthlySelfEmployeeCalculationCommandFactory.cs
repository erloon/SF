using SF.Domain;
using SF.Domain.Commands;
using SF.Domain.Model;

namespace SF.Tests.API.Factories
{
    public static class MonthlySelfEmployeeCalculationCommandFactory
    {
        private const decimal ACIDENTPERCENTAGE = 0.0m;
        private const decimal INCOMECOSTS = 0.0m;
        private const decimal SALARY = 8000m;
        private const decimal VATDEDCUCTIONS = 0m;
        private const TaxationForm TAXIATIONFORM = TaxationForm.GENERAL;

        public static MonthlySelfEmployeeCalculationCommand CreateDefault()
        {
            return new MonthlySelfEmployeeCalculationCommand()
            {
                AccidentContributionPercentage = ACIDENTPERCENTAGE,
                IncomeCosts = INCOMECOSTS,
                IsGross = false,
                IsMedicalInsurance = false,
                IsReliefForSocialInsurance = false,
                Salary = SALARY,
                TaxationForm = TAXIATIONFORM,
                VatAmmountDeduction = VATDEDCUCTIONS,

            };
        }
    }
}