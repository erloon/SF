using System;
using System.Collections.Generic;
using System.Linq;
using SF.Calculator.Core.Model;
using SF.Calculator.Core.Repositories;

namespace SF.Calculator.Core.Services
{
    public class TaxPercentagesService : ITaxPercentagesService
    {
        private readonly IIncomeTaxThresholdRepository _taxThresholdRepository;

        public TaxPercentagesService(IIncomeTaxThresholdRepository taxThresholdRepository)
        {
            _taxThresholdRepository = taxThresholdRepository ?? throw new ArgumentNullException(nameof(taxThresholdRepository));
        }
        public IncomeTaxThreshold GetLinearRate()
        {
            return _taxThresholdRepository.Get(TaxationForm.LINEAR).FirstOrDefault();
            //return new IncomeTaxThreshold(TaxationForm.LINEAR, 1, 0, int.MaxValue, 0.19m);
        }

        public List<IncomeTaxThreshold> GetGeneralIncomeTaxThresholds()
        {
            return _taxThresholdRepository.Get(TaxationForm.GENERAL);
            //return new List<IncomeTaxThreshold>()
            //{
            //   new IncomeTaxThreshold(TaxationForm.GENERAL,1,0,85528m,0.18m),
            //   new IncomeTaxThreshold(TaxationForm.GENERAL,2,85528m,int.MaxValue,0.32m)
            //};
        }

        public List<IncomeTaxThreshold> GetFlatRates()
        {
            return _taxThresholdRepository.Get(TaxationForm.FLAT);
            //throw new System.NotImplementedException();
        }
    }
}