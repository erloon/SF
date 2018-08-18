using SF.Domain;
using SF.Domain.DTO;
using SF.Test.Writables;

namespace SF.Test.Factories
{
    public static class InsuranceContributionContextFactory
    {
        private static decimal INSURANCEBASEAMOUNT = 2665.8m;
        private static decimal HEALTHBASEAMOUNT = 3554.93m;

        private static decimal ACCIDENT = 0.018m;
        private static decimal HEALTH = 0.09m;
        private static decimal HEALTHTODISCOUNT = 0.0775m;
        private static decimal MEDICAL = 0.0245m;
        private static decimal DISABILITI = 0.08m;
        private static decimal LABORFOUND = 0.0245m;
        private static decimal RETIREMENT = 0.1952m;

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
                Percentage = percentage ?? CreateInsuranceContributionsPercentage()
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