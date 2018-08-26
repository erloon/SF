using SF.Domain.DTO;
using SF.Domain.Model;

namespace SF.Domain.Services
{
    public interface IInsuranceContributionService
    {
        InsuranceContributionContext Get(decimal accidentContributionPercentage,  bool withMedical);
        InsuranceContributionContext GetWithDicount(decimal accidentContributionPercentage,  bool withMedical);
    }
}