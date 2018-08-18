using System;
using NUnit.Framework;
using SF.Domain;
using SF.Domain.DTO;
using SF.Test.Factories;

namespace SF.Test.Domain
{
    [TestFixture]
    public class InsuranceContributionTest
    {
        //private decimal ACCIDENT = 0.018m;
        //private decimal HEALTH = 0.09m;
        //private decimal HEALTHTODISCOUNT = 0.0775m;
        //private decimal MEDICAL = 0.0245m;
        //private decimal DISABILITI = 0.08m;
        //private decimal LABORFOUND = 0.0245m;
        //private decimal RETIREMENT = 0.1952m;

        private decimal INSURANCEBASEAMOUNT = 2665.8m;
        private decimal HEALTHBASEAMOUNT = 3554.93m;




        private InsuranceContributionContext CreateContext(decimal? healthBase = null, decimal? insuranceBaseAmount = null, InsuranceContributionsPercentage percentage = null)
        {
            return InsuranceContributionContextFactory.Create(healthBase, insuranceBaseAmount, percentage);
        }

        [Test]
        public void Ctor_SetAllBaseAmounts_Success()
        {
            var context = InsuranceContributionContextFactory.CreateWithPercentage();
            var insuranceContribution = new InsuranceContribution(context);

            Assert.NotNull(insuranceContribution);
            Assert.AreEqual(insuranceContribution.HealthBaseAmount, HEALTHBASEAMOUNT);
            Assert.AreEqual(insuranceContribution.InsuranceBaseAmount, INSURANCEBASEAMOUNT);
            //Assert.NotNull(insuranceContribution.Id);
        }

        [Test]
        public void Ctor_ShouldCalculate_HealthContribution_Success()
        {
            var context = InsuranceContributionContextFactory.CreateWithPercentage();
            var insuranceContribution = new InsuranceContribution(context);

            Assert.AreEqual(319.94m, insuranceContribution.HealthInsurance);
            Assert.AreEqual(275.51m, insuranceContribution.HealthInsuranceDiscount);
        }

        [Test]
        public void Ctor_ShouldCalculate_BaseContribution_Success()
        {
            var context = InsuranceContributionContextFactory.CreateWithPercentage();
            var insuranceContribution = new InsuranceContribution(context);

            Assert.AreEqual(65.31m, insuranceContribution.MedicalInsurance);
            Assert.AreEqual(213.26m, insuranceContribution.DisabilitiInsurance);
            Assert.AreEqual(520.36m, insuranceContribution.RetirementInsurance);
            Assert.AreEqual(47.98m, insuranceContribution.AccidentInsurance);
        }

        [Test]
        public void Ctor_ShouldCalculate_LabourFound_Success()
        {
            var context = InsuranceContributionContextFactory.CreateWithPercentage();
            var insuranceContribution = new InsuranceContribution(context);

            Assert.AreEqual(65.31m, insuranceContribution.LaborFoundInsurance);
        }

        [Test]
        public void Ctor_ShouldThrowwError_IfInsuranceBaseAmountIsInvalid()
        {

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var insuranceContribution = new InsuranceContribution(CreateContext(0));

            });
        }

        [Test]
        public void Ctor_ShouldThrowwError_IfHealthBaseAmountIsInvalid()
        {

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var insuranceContribution = new InsuranceContribution(CreateContext(healthBase: 0m));

            });
        }

        [Test]
        public void Ctor_ShouldThrowwError_IfInsuranceContributionsPercentageIsNull()
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                var insuranceContribution = new InsuranceContribution(CreateContext(percentage: null));
            });
        }

        [Test]
        public void InsuranceContributionsSum_ShouldReturnValueWithoutMedicalInsurance_Success()
        {
            var context = InsuranceContributionContextFactory.CreateWithPercentage();
            var insuranceContribution = new InsuranceContribution(context);

            var insuranceContributionsSum = insuranceContribution.InsuranceContributionsSum(false);

            Assert.NotNull(insuranceContribution);
            Assert.AreEqual(1166.85m, insuranceContributionsSum);
        }

        [Test]
        public void InsuranceContributionsSum_ShouldReturnValueWithMedicalInsurance_Success()
        {
            var context = InsuranceContributionContextFactory.CreateWithPercentage();
            var insuranceContribution = new InsuranceContribution(context);

            var insuranceContributionsSum = insuranceContribution.InsuranceContributionsSum();

            Assert.NotNull(insuranceContribution);
            Assert.AreEqual(1232.16m, insuranceContributionsSum);
        }

        [Test]
        public void SocialInsuranceSum_ShouldReturnValueWithoutMedicalInsurance_Success()
        {
            var context = InsuranceContributionContextFactory.CreateWithPercentage();
            var insuranceContribution = new InsuranceContribution(context);

            var socialInsuranceSum = insuranceContribution.SocialInsuranceContributionSum(false);

            Assert.NotNull(socialInsuranceSum);
            Assert.AreEqual(846.91m, socialInsuranceSum);

        }

        [Test]
        public void SocialInsuranceSum_ShouldReturnValueWithMedicalInsurance_Success()
        {
            var context = InsuranceContributionContextFactory.CreateWithPercentage();
            var insuranceContribution = new InsuranceContribution(context);

            var socialInsuranceSum = insuranceContribution.SocialInsuranceContributionSum();

            Assert.NotNull(socialInsuranceSum);
            Assert.AreEqual(912.22m, socialInsuranceSum);

        }
    }
}