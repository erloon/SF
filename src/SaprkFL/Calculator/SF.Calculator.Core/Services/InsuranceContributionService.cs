using System;
using SF.Calculator.Core.DTO;
using SF.Calculator.Core.Model;
using SF.Calculator.Core.Repositories;

namespace SF.Calculator.Core.Services
{
    public class InsuranceContributionService : IInsuranceContributionService
    {
        private readonly IInsuranceContributionRepository _insuranceContributionRepository;
        private readonly IBaseValuesDictionaryRepository _baseValuesDictionaryRepository;
        private const string HEALTHBASEKEY = "HealthBaseAmount";
        private const string INSURANCEBASEAMOUNTKEY = "InsuranceBaseAmount";
        private const string INSURANCEBASEAMOUNTWITHDICOUNTKEY = "InsuranceBaseAmountWithDiscount";
        public InsuranceContributionService(IInsuranceContributionRepository insuranceContributionRepository, IBaseValuesDictionaryRepository baseValuesDictionaryRepository)
        {
            _insuranceContributionRepository = insuranceContributionRepository ?? throw new ArgumentNullException(nameof(insuranceContributionRepository));
            _baseValuesDictionaryRepository = baseValuesDictionaryRepository ?? throw new ArgumentNullException(nameof(baseValuesDictionaryRepository));
        }
        public InsuranceContributionContext Get(decimal accidentContributionPercentage, bool withMedical)
        {
            return new InsuranceContributionContext()
            {
                HealthBaseAmount = GetValue(HEALTHBASEKEY),
                InsuranceBaseAmount = GetValue(INSURANCEBASEAMOUNTKEY),
                Percentage = _insuranceContributionRepository.GetPercentage(),
                IsMedicalInsurance = withMedical
            };
        }

        public InsuranceContributionContext GetWithDicount(decimal accidentContributionPercentage, bool withMedical)
        {
            return new InsuranceContributionContext()
            {
                HealthBaseAmount = GetValue(HEALTHBASEKEY), 
                InsuranceBaseAmount = GetValue(INSURANCEBASEAMOUNTWITHDICOUNTKEY),
                Percentage = _insuranceContributionRepository.GetPercentage(),
                IsMedicalInsurance = withMedical
            };
        }


        private decimal GetValue(string key)
        {
            var retval = _baseValuesDictionaryRepository.Get(key);

            if (!decimal.TryParse(retval.Value, out var value)) throw new ArgumentException();

            return value;
        }
    }
}