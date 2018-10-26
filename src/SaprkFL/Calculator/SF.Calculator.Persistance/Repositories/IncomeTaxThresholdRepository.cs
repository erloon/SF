using System;
using System.Collections.Generic;
using System.Linq;
using SF.Calculator.Core.Model;
using SF.Calculator.Core.Repositories;

namespace SF.Calculator.Persistence.Repositories
{
    public class IncomeTaxThresholdRepository : IIncomeTaxThresholdRepository
    {
        public List<IncomeTaxThreshold> Get(TaxationForm taxationForm)
        {
            return null;
        }
    }
}