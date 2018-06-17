using System.Collections.Generic;
using NUnit.Framework;
using SF.Domain;
using SF.Tests.Writables;

namespace SF.Tests.Domain.Calculators
{
    [TestFixture]
    public class GeneralCalculatorTest
    {


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
                    .WithToAmount(0m)
                    .WithPercentage(0.32m),
            };
        }

    }
}