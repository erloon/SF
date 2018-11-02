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
        }

        public List<IncomeTaxThreshold> GetGeneralIncomeTaxThresholds()
        {
            return _taxThresholdRepository.Get(TaxationForm.GENERAL);
        }

        public List<IncomeTaxThreshold> GetFlatRates()
        {
            return _taxThresholdRepository.Get(TaxationForm.FLAT);
        }
    }
}