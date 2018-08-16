using System.Collections.Generic;

namespace SF.Domain.Services
{
    public class TaxPercentagesService : ITaxPercentagesService
    {
        public IncomeTaxThreshold GetLinearRate()
        {
            throw new System.NotImplementedException();
        }

        public List<IncomeTaxThreshold> GetGeneralIncomeTaxThresholds()
        {
            throw new System.NotImplementedException();
        }

        public List<IncomeTaxThreshold> GetFlatRates()
        {
            throw new System.NotImplementedException();
        }
    }
}