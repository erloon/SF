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
            Func<TaxationForm, decimal, decimal> getIncomeRate = null;
            return MonthlySelfEmployeeCalculationContextFactory.Create(TaxationForm.LINEAR, null, baseAmount, incomeCost, isGross, contributionContext);
        }

        [Test]
        public void Ctor_SetParameters_Success()
        {
            MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new MonthlySelfEmployeeCalculation(CreataContext());

            Assert.NotNull(monthlySelfEmployeeCalculation.TaxBaseAmount);
            Assert.AreEqual(BASEAMOUNT, monthlySelfEmployeeCalculation.TaxBaseAmount);
            Assert.AreEqual(INCOMECOSTAMOUNT, monthlySelfEmployeeCalculation.IncomeCostsAmount);
        }

        [Test]
        public void Ctor_ThrowError_IfBaseAmountLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MonthlySelfEmployeeCalculation(CreataContext(baseAmount: -9m)));

        }

     
        [Test]
        public void Ctor_ThrowError_IfIncomeCostAmountLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new MonthlySelfEmployeeCalculation(CreataContext(incomeCost: -9m)));

        }
        [Test]
        public void CalculateVatAmount_SetZero_IfTaxBaseAmountLessOrEqualZero()
        {
            MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new MonthlySelfEmployeeCalculation(CreataContext(baseAmount: 0m));

            Assert.NotNull(monthlySelfEmployeeCalculation);
            Assert.AreEqual(0, monthlySelfEmployeeCalculation.VatAmount);
        }

      
        [Test]
        public void CalcualteVatAmount_Success()
        {
            MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new MonthlySelfEmployeeCalculation(CreataContext());

            Assert.NotNull(monthlySelfEmployeeCalculation);
            Assert.AreEqual(230m, monthlySelfEmployeeCalculation.VatAmount);
        }

        [Test]
        public void Ctor_SetInsuranceContribution_Success()
        {
            MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new MonthlySelfEmployeeCalculation(CreataContext());

            Assert.NotNull(monthlySelfEmployeeCalculation);
            Assert.NotNull(monthlySelfEmployeeCalculation.InsuranceContribution);
        }

        [Test]
        public void Ctor_ShouldReturnIncomeTaxZero_IfTaxBaseSumLessOrEqualZero()
        {
            MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new MonthlySelfEmployeeCalculation(CreataContext());

            Assert.NotNull(monthlySelfEmployeeCalculation);
            Assert.AreEqual(0, monthlySelfEmployeeCalculation.TaxAmount);
        }

        [Test]
        public void Ctor_ShouldReturIncomTax_Success()
        {
            MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new MonthlySelfEmployeeCalculation(CreataContext(baseAmount: 10000));

            Assert.NotNull(monthlySelfEmployeeCalculation);
            Assert.AreEqual(1326m, monthlySelfEmployeeCalculation.TaxAmount);
        }

        [Test]
        public void Ctor_TaxAmountShouldBeRound()
        {
            MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new MonthlySelfEmployeeCalculation(CreataContext(baseAmount: 10000));

            Assert.NotNull(monthlySelfEmployeeCalculation);
            Assert.IsTrue((monthlySelfEmployeeCalculation.TaxAmount % 1) == 0);
        }

        [Test]
        public void Ctor_CalcuateNetPay_Success()
        {
            MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new MonthlySelfEmployeeCalculation(CreataContext(baseAmount: 10000));
            Assert.NotNull(monthlySelfEmployeeCalculation);

            Assert.AreEqual(7007.15m, monthlySelfEmployeeCalculation.NetPay);
        }

        [Test]
        public void Ctor_CalculateNetPayEstimate_Success()
        {
            MonthlySelfEmployeeCalculation monthlySelfEmployeeCalculation = new MonthlySelfEmployeeCalculation(CreataContext(baseAmount: 10000));
            Assert.NotNull(monthlySelfEmployeeCalculation);

            Assert.AreEqual(7507.15m, monthlySelfEmployeeCalculation.NetPayEstimate);
        }
    }
}