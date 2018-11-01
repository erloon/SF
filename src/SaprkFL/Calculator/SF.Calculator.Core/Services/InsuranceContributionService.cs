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
                Percentage =  new InsuranceContributionsPercentage(0,0.09m,0.1952m,0.0775m,0.08m, 0.0245m,0.0245m,true),
                IsMedicalInsurance = withMedical
            };
        }

        public InsuranceContributionContext GetWithDicount(decimal accidentContributionPercentage,  bool withMedical)
        {
            return new InsuranceContributionContext()
            {
                HealthBaseAmount = 3554.93m,
                InsuranceBaseAmount = 630m,
                Percentage = new InsuranceContributionsPercentage(0,0.09m,0.1952m,0.0775m,0.08m, 0.0245m,0.0245m,true),
                IsMedicalInsurance = withMedical
            };
        }
    }
}