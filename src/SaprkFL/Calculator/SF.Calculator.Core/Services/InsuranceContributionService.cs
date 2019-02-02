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
        private const string INSURANCEBASEAMOUNTWITHSTARTKEY = "InsuranceBaseAmountWithStartDiscount";
        public InsuranceContributionService(IInsuranceContributionRepository insuranceContributionRepository, IBaseValuesDictionaryRepository baseValuesDictionaryRepository)
        {
            _insuranceContributionRepository = insuranceContributionRepository ?? throw new ArgumentNullException(nameof(insuranceContributionRepository));
            _baseValuesDictionaryRepository = baseValuesDictionaryRepository ?? throw new ArgumentNullException(nameof(baseValuesDictionaryRepository));
        }

        public InsuranceContributionContext Create(InsuranceContributionForm insuranceContribution,decimal accidentContributionPercentage, bool withMedical)
        {
            var key = GetInsuranceBaseAmountKey(insuranceContribution);
            return new InsuranceContributionContext()
            {
                HealthBaseAmount = GetValue(HEALTHBASEKEY),
                InsuranceBaseAmount = GetValue(key),
                Percentage = _insuranceContributionRepository.GetPercentage(),
                IsMedicalInsurance = withMedical
            };
        }

        private string GetInsuranceBaseAmountKey(InsuranceContributionForm insuranceContribution)
        {
            string key;
            switch (insuranceContribution)
            {
                case InsuranceContributionForm.LACK:
                    key = INSURANCEBASEAMOUNTWITHSTARTKEY;
                    break;
                case InsuranceContributionForm.NORMAL:
                    key = INSURANCEBASEAMOUNTKEY;
                    break;
                case InsuranceContributionForm.PREFERENTIAL:
                    key = INSURANCEBASEAMOUNTWITHDICOUNTKEY;
                    break;
                default:
                    key = INSURANCEBASEAMOUNTKEY;
                    break;
            }

            return key;
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

        public InsuranceContributionContext GetWithDiscount(decimal accidentContributionPercentage, bool withMedical)
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