using System;
using NUnit.Framework;
using SF.Domain;
using SF.Tests.Writables;

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

        private decimal INSURANCEBASEAMOUNT = 2665.8m;
        private decimal HEALTHBASEAMOUNT = 3554.93m;


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
            var insuranceContribution = new InsuranceContribution(INSURANCEBASEAMOUNT, HEALTHBASEAMOUNT, CreateInsuranceContributionsPercentage());

            Assert.NotNull(insuranceContribution);
            Assert.AreEqual(insuranceContribution.HealthBaseAmount, HEALTHBASEAMOUNT);
            Assert.AreEqual(insuranceContribution.InsuranceBaseAmount, INSURANCEBASEAMOUNT);
            Assert.NotNull(insuranceContribution.Id);
        }

        [Test]
        public void Ctor_ShouldCalculate_HealthContribution_Success()
        {
            var insuranceContribution = new InsuranceContribution(INSURANCEBASEAMOUNT, HEALTHBASEAMOUNT, CreateInsuranceContributionsPercentage());

            Assert.AreEqual(319.94m, insuranceContribution.HealthInsurance);
            Assert.AreEqual(275.51m, insuranceContribution.HealthInsuranceDiscount);
        }

        [Test]
        public void Ctor_ShouldCalculate_BaseContribution_Success()
        {
            var insuranceContribution = new InsuranceContribution(INSURANCEBASEAMOUNT, HEALTHBASEAMOUNT, CreateInsuranceContributionsPercentage());

            Assert.AreEqual(65.31m, insuranceContribution.MedicalInsurance);
            Assert.AreEqual(213.26m, insuranceContribution.DisabilitiInsurance);
            Assert.AreEqual(520.36m, insuranceContribution.RetirementInsurance);
            Assert.AreEqual(47.98m, insuranceContribution.AccidentInsurance);
        }

        [Test]
        public void Ctor_ShouldCalculate_LabourFound_Success()
        {
            var insuranceContribution = new InsuranceContribution(INSURANCEBASEAMOUNT, HEALTHBASEAMOUNT, CreateInsuranceContributionsPercentage());

            Assert.AreEqual(65.31m, insuranceContribution.LaborFoundInsurance);
        }

        [Test]
        public void Ctor_ShouldThrowwError_IfInsuranceBaseAmountIsInvalid()
        {

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var insuranceContribution = new InsuranceContribution(0, HEALTHBASEAMOUNT,
                    CreateInsuranceContributionsPercentage());

            });
        }

        [Test]
        public void Ctor_ShouldThrowwError_IfHealthBaseAmountIsInvalid()
        {

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var insuranceContribution = new InsuranceContribution(INSURANCEBASEAMOUNT, 0,
                    CreateInsuranceContributionsPercentage());

            });
        }

        [Test]
        public void Ctor_ShouldThrowwError_IfInsuranceContributionsPercentageIsNull()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                var insuranceContribution = new InsuranceContribution(INSURANCEBASEAMOUNT, HEALTHBASEAMOUNT,null);
            });
        }

        [Test]
        public void InsuranceContributionsSum_ShouldReturnValue_Success()
        {
            var insuranceContribution = new InsuranceContribution(INSURANCEBASEAMOUNT, HEALTHBASEAMOUNT, CreateInsuranceContributionsPercentage());

            var insuranceContributionsSum = insuranceContribution.InsuranceContributionsSum();

            Assert.NotNull(insuranceContribution);
            Assert.AreEqual(1166.85m, insuranceContributionsSum);
        }

        [Test]
        public void ISocialInsuranceSum_ShouldReturnValue_Success()
        {
            var insuranceContribution = new InsuranceContribution(INSURANCEBASEAMOUNT, HEALTHBASEAMOUNT, CreateInsuranceContributionsPercentage());

            var socialInsuranceSum = insuranceContribution.SocialInsuranceSum();

            Assert.NotNull(insuranceContribution);
            Assert.AreEqual(846.91, socialInsuranceSum);
        }
    }
}