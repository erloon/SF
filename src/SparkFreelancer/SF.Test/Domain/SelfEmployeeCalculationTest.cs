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
            var calculation = new YearlySelfEmployeeCalculation();

            Assert.NotNull(calculation);
            Assert.AreEqual(0, calculation.TotalIncomes);
            Assert.AreEqual(0, calculation.TotalCosts);
            Assert.NotNull(calculation.Id);
            Assert.NotNull(calculation.Calculations);
        }

        [Test]
        public void Calcualte_ShouldThrowError_ifContextIsNull()
        {
            var calculation = new YearlySelfEmployeeCalculation();

            Assert.Throws<ArgumentNullException>(() => calculation.Calculate(null));
        }

        //[Test]
        //public void Calculate_ShouldCreate_OneMonthlyCalculations()
        //{
        //    var calculationContext = YearlySelfEmployeeCalculationContextFactory.Create(TaxationForm.GENERAL);
        //    var calculation = new YearlySelfEmployeeCalculation();


        //    calculation.Calculate(calculationContext);

        //    Assert.NotNull(calculation);
        //    Assert.AreEqual(96000m, calculation.TotalIncomes);
        //    Assert.AreEqual(12000m, calculation.TotalCosts);
        //    Assert.AreEqual(12, calculation.Calculations.Count);
        //}
    }
}