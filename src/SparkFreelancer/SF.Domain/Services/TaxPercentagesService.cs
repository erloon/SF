using System;
using System.Collections.Generic;

namespace SF.Domain.Services
{
    public class TaxPercentagesService : ITaxPercentagesService
    {
        public IncomeTaxThreshold GetLinearRate()
        {
            return new IncomeTaxThreshold(TaxationForm.LINEAR, 1, 0, int.MaxValue, 0.19m);
        }

        public List<IncomeTaxThreshold> GetGeneralIncomeTaxThresholds()
        {
            return new List<IncomeTaxThreshold>()
            {
               new IncomeTaxThreshold(TaxationForm.GENERAL,1,0,85528m,0.18m),
               new IncomeTaxThreshold(TaxationForm.GENERAL,2,85528m,int.MaxValue,0.32m)
            };
        }

        public List<IncomeTaxThreshold> GetFlatRates()
        {
            throw new System.NotImplementedException();
        }
    }
}