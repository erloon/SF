using SF.Calculator.Core.DTO;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Core.Services
{
    public interface IInsuranceContributionService
    {
        InsuranceContributionContext Get(decimal accidentContributionPercentage,  bool withMedical);
        InsuranceContributionContext GetWithDiscount(decimal accidentContributionPercentage,  bool withMedical);

        InsuranceContributionContext Create(InsuranceContributionForm insuranceContribution,
            decimal accidentContributionPercentage, bool withMedical);
    }
}