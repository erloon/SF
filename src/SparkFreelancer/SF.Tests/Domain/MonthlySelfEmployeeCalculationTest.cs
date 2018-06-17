using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SF.Domain;
using SF.Domain.DTO;
using SF.Tests.Factories;

namespace SF.Tests.Domain
{
    [TestFixture]
    public class MonthlySelfEmployeeCalculationTest
    {
        private const decimal BASEAMOUNT = 1000m;
        private const decimal VATRATE = 0.23m;
        private const decimal INCOMECOSTAMOUNT = 500m;

        private MonthlySelfEmployeeCalculationContext CreataContext(decimal? baseAmount = null, decimal? vatRate = null, decimal? incomeCost = null, InsuranceContributionContext contributionContext = null)
        {
            Func<TaxationForm, decimal, decimal> getIncomeRate = (form, baseamount) => 0.19m;
            return MonthlySelfEmployeeCalculationContextFactory.Create(TaxationForm.LINEAR, getIncomeRate, baseAmount, vatRate, incomeCost, contributionContext);
        }

        [Test]
        public void Ctor_SetParameters_Success()
        {
            SF.Domain.MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new SF.Domain.MonthlySelfEmployeeCalculation(CreataContext());

            Assert.NotNull(monthlySelfEmployeeCalculation.TaxBaseAmount);
            Assert.AreEqual(BASEAMOUNT, monthlySelfEmployeeCalculation.TaxBaseAmount);
            Assert.AreEqual(INCOMECOSTAMOUNT, monthlySelfEmployeeCalculation.IncomeCostsAmount);
        }

        [Test]
        public void Ctor_ThrowError_IfBaseAmountLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SF.Domain.MonthlySelfEmployeeCalculation(CreataContext(baseAmount: -9m)));

        }

        [Test]
        public void Ctor_ThrowError_IfVatRateLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SF.Domain.MonthlySelfEmployeeCalculation(CreataContext(vatRate: -8m)));

        }
        [Test]
        public void Ctor_ThrowError_IfIncomeCostAmountLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SF.Domain.MonthlySelfEmployeeCalculation(CreataContext(incomeCost: -9m)));

        }
        [Test]
        public void CalculateVatAmount_SetZero_IfTaxBaseAmountLessOrEqualZero()
        {
            SF.Domain.MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new SF.Domain.MonthlySelfEmployeeCalculation(CreataContext(baseAmount: 0m));

            Assert.NotNull(monthlySelfEmployeeCalculation);
            Assert.AreEqual(0, monthlySelfEmployeeCalculation.VatAmount);
        }

        [Test]
        public void CalculateVatAmount_SetZero_IfTaxVatRateLessOrEqualZero()
        {
            SF.Domain.MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new SF.Domain.MonthlySelfEmployeeCalculation(CreataContext(vatRate: 0m));

            Assert.NotNull(monthlySelfEmployeeCalculation);
            Assert.AreEqual(0, monthlySelfEmployeeCalculation.VatAmount);
        }

        [Test]
        public void CalcualteVatAmount_Success()
        {
            SF.Domain.MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new SF.Domain.MonthlySelfEmployeeCalculation(CreataContext());

            Assert.NotNull(monthlySelfEmployeeCalculation);
            Assert.AreEqual(230m, monthlySelfEmployeeCalculation.VatAmount);
        }

        [Test]
        public void Ctor_SetInsuranceContribution_Success()
        {
            SF.Domain.MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new SF.Domain.MonthlySelfEmployeeCalculation(CreataContext());

            Assert.NotNull(monthlySelfEmployeeCalculation);
            Assert.NotNull(monthlySelfEmployeeCalculation.InsuranceContribution);
        }

        [Test]
        public void Ctor_ShouldReturnIncomeTaxZero_IfTaxBaseSumLessOrEqualZero()
        {
            SF.Domain.MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new SF.Domain.MonthlySelfEmployeeCalculation(CreataContext());

            Assert.NotNull(monthlySelfEmployeeCalculation);
            Assert.AreEqual(0, monthlySelfEmployeeCalculation.TaxAmount);
        }

        [Test]
        public void Ctor_ShouldReturIncomTax_Success()
        {
            SF.Domain.MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new SF.Domain.MonthlySelfEmployeeCalculation(CreataContext(baseAmount: 10000));

            Assert.NotNull(monthlySelfEmployeeCalculation);
            Assert.AreEqual(1369, monthlySelfEmployeeCalculation.TaxAmount);
        }

        [Test]
        public void Ctor_TaxAmountShouldBeRound()
        {
            SF.Domain.MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new SF.Domain.MonthlySelfEmployeeCalculation(CreataContext(baseAmount: 10000));

            Assert.NotNull(monthlySelfEmployeeCalculation);
            Assert.IsTrue((monthlySelfEmployeeCalculation.TaxAmount % 1) == 0);
        }

        [Test]
        public void Ctor_CalcuateNetPay_Success()
        {
            SF.Domain.MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new SF.Domain.MonthlySelfEmployeeCalculation(CreataContext(baseAmount: 10000));
            Assert.NotNull(monthlySelfEmployeeCalculation);

            Assert.AreEqual(6964.15m,monthlySelfEmployeeCalculation.NetPay);
        }

        [Test]
        public void Ctor_CalculateNetPayEstimate_Success()
        {
            SF.Domain.MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new SF.Domain.MonthlySelfEmployeeCalculation(CreataContext(baseAmount: 10000));
            Assert.NotNull(monthlySelfEmployeeCalculation);

            Assert.AreEqual(7464.15m, monthlySelfEmployeeCalculation.NetPayEstimate);
        }
    }
}