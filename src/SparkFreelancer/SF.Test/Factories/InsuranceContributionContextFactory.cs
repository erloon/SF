using SF.Domain;
using SF.Domain.DTO;
using SF.Domain.Model;
using SF.Test.Writables;

namespace SF.Test.Factories
{
    public static class InsuranceContributionContextFactory
    {
        private const decimal INSURANCEBASEAMOUNT = 2665.8m;
        private const decimal HEALTHBASEAMOUNT = 3554.93m;

        private const decimal ACCIDENT = 0.018m;
        private const decimal HEALTH = 0.09m;
        private const decimal HEALTHTODISCOUNT = 0.0775m;
        private const decimal MEDICAL = 0.0245m;
        private const decimal DISABILITI = 0.08m;
        private const decimal LABORFOUND = 0.0245m;
        private const decimal RETIREMENT = 0.1952m;
        private const bool WITHMEDICAL = true;

        public static InsuranceContributionContext Create(decimal? healthBase = null, decimal? insuranceBaseAmount = null, InsuranceContributionsPercentage percentage = null)
        {
            return new InsuranceContributionContext()
            {
                HealthBaseAmount = healthBase ?? HEALTHBASEAMOUNT,
                InsuranceBaseAmount = insuranceBaseAmount ?? INSURANCEBASEAMOUNT,
                Percentage = percentage
            };
        }

        public static InsuranceContributionContext CreateWithPercentage(decimal? healthBase = null, decimal? insuranceBaseAmount = null, InsuranceContributionsPercentage percentage = null)
        {
            return new InsuranceContributionContext()
            {
                HealthBaseAmount = healthBase ?? HEALTHBASEAMOUNT,
                InsuranceBaseAmount = insuranceBaseAmount ?? INSURANCEBASEAMOUNT,
                Percentage = percentage ?? CreateInsuranceContributionsPercentage(),
                IsMedicalInsurance = WITHMEDICAL
            };
        }
        private static InsuranceContributionsPercentage CreateInsuranceContributionsPercentage()
        {
            return new WritableInsuranceContributionsPercentage()
                .WithAccident(ACCIDENT)
                .WithHealth(HEALTH)
                .WithHealthToDiscount(HEALTHTODISCOUNT)
                .WithMedical(MEDICAL)
                .WithDisabiliti(DISABILITI)
                .WithLaborFound(LABORFOUND)
                .WithRetirement(RETIREMENT);
        }
    }
}