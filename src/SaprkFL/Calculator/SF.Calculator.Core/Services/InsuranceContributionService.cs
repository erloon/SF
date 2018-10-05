using SF.Calculator.Core.DTO;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Core.Services
{
    public class InsuranceContributionService : IInsuranceContributionService
    {
        public InsuranceContributionContext Get(decimal accidentContributionPercentage, bool withMedical)
        {
            return new InsuranceContributionContext()
            {
                HealthBaseAmount = 3554.93m,
                InsuranceBaseAmount = 2665.8m,
                Percentage = new InsuranceContributionsPercentage()
                {
                    Accident = accidentContributionPercentage,
                    Health = 0.09m,
                    Disabiliti = 0.08m,
                    HealthToDiscount = 0.0775m,
                    LaborFound = 0.0245m,
                    Medical = 0.0245m,
                    Retirement = 0.1952m
                },
                IsMedicalInsurance = withMedical
            };
        }

        public InsuranceContributionContext GetWithDicount(decimal accidentContributionPercentage,  bool withMedical)
        {
            return new InsuranceContributionContext()
            {
                HealthBaseAmount = 3554.93m,
                InsuranceBaseAmount = 630m,
                Percentage = new InsuranceContributionsPercentage()
                {
                    Accident = accidentContributionPercentage,
                    Health = 0.09m,
                    Disabiliti = 0.08m,
                    HealthToDiscount = 0.0775m,
                    LaborFound = 0.0245m,
                    Medical = 0.0245m,
                    Retirement = 0.1952m
                },
                IsMedicalInsurance = withMedical
            };
        }
    }
}