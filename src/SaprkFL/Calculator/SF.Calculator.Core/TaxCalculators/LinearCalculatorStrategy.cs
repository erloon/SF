using System;
using SF.Calculator.Core.DTO;
using SF.Calculator.Core.Model;
using SF.Calculator.Core.Services;
using SF.Shared.Infrastructure;

namespace SF.Calculator.Core.TaxCalculators
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