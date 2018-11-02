using System;
using System.Linq;
using SF.Calculator.Core.Model;
using SF.Calculator.Core.Repositories;

namespace SF.Calculator.Persistence.Repositories
{
    public class InsuranceContributionRepository : IInsuranceContributionRepository
    {
        private readonly SFCalculatorContext _context;

        public InsuranceContributionRepository(SFCalculatorContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public InsuranceContributionsPercentage GetPercentage()
        {
            return _context.InsuranceContributionsPercentages.FirstOrDefault(x => x.IsActive);
        }
    }
}