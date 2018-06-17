using System.Collections.Generic;

namespace SF.Domain.Services
{
    public class TaxPercentagesService : ITaxPercentagesService
    {
        public decimal GetLinearRate()
        {
            throw new System.NotImplementedException();
        }

        public List<IncomeTaxThreshold> GetGeneralIncomeTaxThresholds()
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetFlatRates()
        {
            throw new System.NotImplementedException();
        }
    }
}