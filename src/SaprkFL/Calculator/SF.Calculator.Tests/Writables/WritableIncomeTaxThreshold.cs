using SF.Calculator.Core.Model;

namespace SF.Calculator.Tests.Writables
{
    public class WritableIncomeTaxThreshold : IncomeTaxThreshold
    {
        public WritableIncomeTaxThreshold WithTaxationForm(TaxationForm taxationForm)
        {
            this.TaxationForm = taxationForm;
            return this;
        }

        public WritableIncomeTaxThreshold WithNumber(int number)
        {
            this.ThresholdNumber = number;
            return this;
        }

        public WritableIncomeTaxThreshold WithFromAmount(decimal fromAmount)
        {
            this.FromAmount = fromAmount;
            return this;
        }

        public WritableIncomeTaxThreshold WithToAmount(decimal toAmount)
        {
            this.ToAmount = toAmount;
            return this;
        }

        public WritableIncomeTaxThreshold WithPercentage(decimal percentage)
        {
            this.Percentage = percentage;
            return this;
        }
    }
}