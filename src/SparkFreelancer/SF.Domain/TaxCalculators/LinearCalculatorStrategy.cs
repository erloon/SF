using System;
using SF.Domain.DTO;
using SF.Domain.Services;
using SF.Infrastructure;

namespace SF.Domain.TaxCalculators
{
    public class LinearCalculatorStrategy : ITaxCalculatorStrategy

    {
        private readonly ITaxPercentagesService _taxPercentagesService;

        public LinearCalculatorStrategy(ITaxPercentagesService taxPercentagesService)
        {
            _taxPercentagesService = taxPercentagesService;
        }


        public decimal Calculate(TaxCalculationContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var percentage = GetTaxPercentage();
            return context.CurrentIncome * percentage;
        }

        private decimal GetTaxPercentage()
        {
            IncomeTaxThreshold incomeTaxThreshold = _taxPercentagesService.GetLinearRate() ?? throw new DomainException("Tax percentages not found");

            return incomeTaxThreshold.Percentage;
        }
    }
}