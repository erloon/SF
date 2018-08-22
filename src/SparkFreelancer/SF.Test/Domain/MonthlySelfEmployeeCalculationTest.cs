using System;
using NUnit.Framework;
using SF.Domain;
using SF.Domain.DTO;
using SF.Domain.Model;
using SF.Test.Factories;

namespace SF.Test.Domain
{
    [TestFixture]
    public class MonthlySelfEmployeeCalculationTest
    {
        private const decimal BASEAMOUNT = 1000m;
        private const decimal INCOMECOSTAMOUNT = 500m;


        private MonthlySelfEmployeeCalculationContext CreataContext(decimal? baseAmount = null, decimal? incomeCost = null,bool? isGross = null,InsuranceContributionContext contributionContext = null)
        {
            return MonthlySelfEmployeeCalculationContextFactory.Create(TaxationForm.LINEAR, null, baseAmount, incomeCost, isGross, contributionContext);
        }

        [Test]
        public void Ctor_SetParameters_Success()
        {
            SelfEmployeeCalculation selfEmployeeCalculation = new SelfEmployeeCalculation(CreataContext());

            Assert.NotNull(selfEmployeeCalculation.TaxBaseAmount);
            Assert.AreEqual(BASEAMOUNT, selfEmployeeCalculation.TaxBaseAmount);
            Assert.AreEqual(INCOMECOSTAMOUNT, selfEmployeeCalculation.IncomeCostsAmount);
        }

        [Test]
        public void Ctor_ThrowError_IfBaseAmountLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SelfEmployeeCalculation(CreataContext(baseAmount: -9m)));

        }

     
        [Test]
        public void Ctor_ThrowError_IfIncomeCostAmountLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SelfEmployeeCalculation(CreataContext(incomeCost: -9m)));

        }
        [Test]
        public void CalculateVatAmount_SetZero_IfTaxBaseAmountLessOrEqualZero()
        {
            SelfEmployeeCalculation selfEmployeeCalculation = new SelfEmployeeCalculation(CreataContext(baseAmount: 0m));

            Assert.NotNull(selfEmployeeCalculation);
            Assert.AreEqual(0, selfEmployeeCalculation.VatAmount);
        }

      
        [Test]
        public void CalcualteVatAmount_Success()
        {
            SelfEmployeeCalculation selfEmployeeCalculation = new SelfEmployeeCalculation(CreataContext());

            Assert.NotNull(selfEmployeeCalculation);
            Assert.AreEqual(230m, selfEmployeeCalculation.VatAmount);
        }

        [Test]
        public void Ctor_SetInsuranceContribution_Success()
        {
            SelfEmployeeCalculation selfEmployeeCalculation = new SelfEmployeeCalculation(CreataContext());

            Assert.NotNull(selfEmployeeCalculation);
            Assert.NotNull(selfEmployeeCalculation.InsuranceContribution);
        }

        [Test]
        public void Ctor_ShouldReturnIncomeTaxZero_IfTaxBaseSumLessOrEqualZero()
        {
            SelfEmployeeCalculation selfEmployeeCalculation = new SelfEmployeeCalculation(CreataContext());

            Assert.NotNull(selfEmployeeCalculation);
            Assert.AreEqual(0, selfEmployeeCalculation.TaxAmount);
        }

        [Test]
        public void Ctor_ShouldReturIncomTax_Success()
        {
            SelfEmployeeCalculation selfEmployeeCalculation = new SelfEmployeeCalculation(CreataContext(baseAmount: 10000));

            Assert.NotNull(selfEmployeeCalculation);
            Assert.AreEqual(1326m, selfEmployeeCalculation.TaxAmount);
        }

        [Test]
        public void Ctor_TaxAmountShouldBeRound()
        {
            SelfEmployeeCalculation selfEmployeeCalculation = new SelfEmployeeCalculation(CreataContext(baseAmount: 10000));

            Assert.NotNull(selfEmployeeCalculation);
            Assert.IsTrue((selfEmployeeCalculation.TaxAmount % 1) == 0);
        }

        [Test]
        public void Ctor_CalcuateNetPay_Success()
        {
            SelfEmployeeCalculation selfEmployeeCalculation = new SelfEmployeeCalculation(CreataContext(baseAmount: 10000));
            Assert.NotNull(selfEmployeeCalculation);

            Assert.AreEqual(7007.15m, selfEmployeeCalculation.NetPay);
        }

        [Test]
        public void Ctor_CalculateNetPayEstimate_Success()
        {
            SelfEmployeeCalculation selfEmployeeCalculation = new SelfEmployeeCalculation(CreataContext(baseAmount: 10000));
            Assert.NotNull(selfEmployeeCalculation);

            Assert.AreEqual(7507.15m, selfEmployeeCalculation.NetPayEstimate);
        }
    }
}