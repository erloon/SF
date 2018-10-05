using SF.Calculator.Core.DTO;

namespace SF.Calculator.Core.Services
{
    public interface IInsuranceContributionService
    {
        InsuranceContributionContext Get(decimal accidentContributionPercentage,  bool withMedical);
        InsuranceContributionContext GetWithDicount(decimal accidentContributionPercentage,  bool withMedical);
    }
}