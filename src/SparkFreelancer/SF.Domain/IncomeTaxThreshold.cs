using SF.Infrastructure;

namespace SF.Domain
{
    public class IncomeTaxThreshold : Entity
    {
        public TaxationForm TaxationForm { get; protected set; }
        public int ThresholdNumber { get; protected set; }
        public decimal FromAmount { get; protected set; }
        public decimal ToAmount { get; protected set; }
        public decimal Percentage { get; protected set; }

        public decimal PreviusMaxTaxValue
        {
            get
            {
                return ToAmount * Percentage;
            }
        }
    }
}