using System;
using NUnit.Framework;
using SF.Domain;
using SF.Domain.Model;
using SF.Test.Factories;

namespace SF.Test.Domain
{
    [TestFixture]
    public class SelfEmployeeCalculationTest
    {
        [Test]
        public void Ctor_ShouldCreateProperties()
        {
            var calculation = new SelfEmployeeCalculation();

            Assert.NotNull(calculation);
            Assert.AreEqual(0, calculation.TotalIncomes);
            Assert.AreEqual(0, calculation.TotalCosts);
            Assert.NotNull(calculation.Id);
            Assert.NotNull(calculation.Calculations);
        }

        [Test]
        public void Calcualte_ShouldThrowError_ifContextIsNull()
        {
            var calculation = new SelfEmployeeCalculation();

            Assert.Throws<ArgumentNullException>(() => calculation.Calculate(null));
        }

        [Test]
        public void Calculate_ShouldCreate_OneMonthlyCalculations()
        {
            var calculationContext = SelfEmployeeCalculationContextFactory.Create(TaxationForm.GENERAL);
            var calculation = new SelfEmployeeCalculation();


            calculation.Calculate(calculationContext);

            Assert.NotNull(calculation);
            Assert.AreEqual(96000m, calculation.TotalIncomes);
            Assert.AreEqual(12000m, calculation.TotalCosts);
            Assert.AreEqual(12, calculation.Calculations.Count);
        }
    }
}