namespace SF.Tests.Domain
{
    [TestFixture]
    public class InsuranceContributionTest
    {
        private decimal ACCIDENT = 0.018m;
        private decimal HEALTH = 0.09m;
        private decimal HEALTHTODISCOUNT = 0.0775m;
        private decimal MEDICAL = 0.0245m;
        private decimal DISABILITI = 0.08m;
        private decimal LABORFOUND = 0.0245m;
        private decimal RETIREMENT = 0.1952m;


        private InsuranceContributionsPercentage CreateInsuranceContributionsPercentage()
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

        [Test]
        public void Ctor_SetAllBaseAmounts_Success()
        {
            decimal insuranceBaseAmount = 2665.8m;
            decimal healthBaseAmount = 3554.93m;

            var InsuranceContribution = new InsuranceContribution(insuranceBaseAmount, healthBaseAmount, CreateInsuranceContributionsPercentage());

            Assert.NotNull(insuranceBaseAmount);
        }
    }
}