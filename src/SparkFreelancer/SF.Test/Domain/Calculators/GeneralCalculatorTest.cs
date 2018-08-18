using System;
using System.Collections;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SF.Domain;
using SF.Domain.DTO;
using SF.Domain.Services;
using SF.Domain.TaxCalculators;
using SF.Test.Writables;

namespace SF.Test.Domain.Calculators
{
    [TestFixture]
    public class GeneralCalculatorTest
    {
        private Mock<ITaxPercentagesService> _taxPercentagesService = null;
        private GeneralCalculatorStrategy _calculatorStrategy = null;
        public List<IncomeTaxThreshold> CreateThreshlds()
        {
            return new List<IncomeTaxThreshold>()
            {
                new WritableIncomeTaxThreshold()
                    .WithTaxationForm(TaxationForm.GENERAL)
                    .WithNumber(1)
                    .WithFromAmount(0m)
                    .WithToAmount(85528m)
                    .WithPercentage(0.18m),
                new WritableIncomeTaxThreshold()
                    .WithTaxationForm(TaxationForm.GENERAL)
                    .WithNumber(2)
                    .WithFromAmount(85528.01m)
                    .WithToAmount(150000m)
                    .WithPercentage(0.32m),
                new WritableIncomeTaxThreshold()
                    .WithTaxationForm(TaxationForm.GENERAL)
                    .WithNumber(3)
                    .WithFromAmount(150000.01m)
                    .WithToAmount(Decimal.MaxValue)
                    .WithPercentage(0.50m),
            };
        }

        [SetUp]
        public void Setup()
        {
            _taxPercentagesService = new Mock<ITaxPercentagesService>(MockBehavior.Default);
            _calculatorStrategy = new GeneralCalculatorStrategy(_taxPercentagesService.Object);
        }

        [Test]
        public void Calculate_ShouldThrowException_IfContextNull()
        {
            Assert.Throws<ArgumentNullException>(() => _calculatorStrategy.Calculate(null));
        }

        [Test, TestCaseSource(typeof(TaxCalculationContextTestCaseFactory), "TestCases")]
        public decimal Calcualte_ShouldCalculate_Success(TaxCalculationContext context)
        {
            _taxPercentagesService.Setup(x => x.GetGeneralIncomeTaxThresholds()).Returns(CreateThreshlds());

            return _calculatorStrategy.Calculate(context);
        }

    }

    public class TaxCalculationContextTestCaseFactory
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new TaxCalculationContext(0m, 8000m)).Returns(1440m);
                yield return new TestCaseData(new TaxCalculationContext(80000m, 5528m)).Returns(995.04m);
                yield return new TestCaseData(new TaxCalculationContext(80000m, 8000m)).Returns(1786.08m);
                yield return new TestCaseData(new TaxCalculationContext(85528.02m, 8000m)).Returns(2560m);
                yield return new TestCaseData(new TaxCalculationContext(100000m, 8000m)).Returns(2560m);
                yield return new TestCaseData(new TaxCalculationContext(150001, 8000m)).Returns(4000m);
            }
        }
    }
}