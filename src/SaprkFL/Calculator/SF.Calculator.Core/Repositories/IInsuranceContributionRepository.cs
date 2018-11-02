using SF.Calculator.Core.Model;

namespace SF.Calculator.Core.Repositories
{
    public interface IInsuranceContributionRepository
    {
        InsuranceContributionsPercentage GetPercentage();
    }
}