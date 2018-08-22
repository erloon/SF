using SF.Domain.DTO;
using SF.Domain.Model;

namespace SF.Domain.Services
{
    public interface IInsuranceContributionService
    {
        InsuranceContributionContext Get(decimal accidentContributionPercentage);
        InsuranceContributionContext GetWithDicount(decimal accidentContributionPercentage);
    }
}