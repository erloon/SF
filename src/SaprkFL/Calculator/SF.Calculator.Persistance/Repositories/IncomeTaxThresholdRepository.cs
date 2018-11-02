using System;
using System.Collections.Generic;
using System.Linq;
using SF.Calculator.Core.Model;
using SF.Calculator.Core.Repositories;

namespace SF.Calculator.Persistence.Repositories
{
    public class IncomeTaxThresholdRepository : IIncomeTaxThresholdRepository
    {
        private readonly SFCalculatorContext _context;

        public IncomeTaxThresholdRepository(SFCalculatorContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public List<IncomeTaxThreshold> Get(TaxationForm taxationForm)
        {
            return _context.IncomeTaxThresholds.Where(x => x.TaxationForm.Equals(taxationForm)).ToList();
        }
    }
}