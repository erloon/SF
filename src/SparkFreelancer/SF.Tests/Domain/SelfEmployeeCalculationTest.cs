using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SF.Domain;
using SF.Domain.DTO;
using SF.Tests.Factories;

namespace SF.Tests.Domain
{
    [TestFixture]
    public class SelfEmployeeCalculationTest
    {
        private const decimal BASEAMOUNT = 1000m;
        private const decimal VATRATE = 0.23m;
        private const decimal INCOMECOSTAMOUNT = 500m;

        private SelfEmployeeCalculationContext CreataContext(decimal? baseAmount = null, decimal? vatRate = null, decimal? incomeCost = null, InsuranceContributionContext contributionContext = null)
        {
            return SelfEmployeeCalculationContextFactory.Create(baseAmount, vatRate, incomeCost, contributionContext);
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
        public void Ctor_ThrowError_IfVatRateLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SelfEmployeeCalculation(CreataContext(vatRate: -8m)));

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
        public void CalculateVatAmount_SetZero_IfTaxVatRateLessOrEqualZero()
        {
            SelfEmployeeCalculation selfEmployeeCalculation = new SelfEmployeeCalculation(CreataContext(vatRate: 0m));

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

    }
}