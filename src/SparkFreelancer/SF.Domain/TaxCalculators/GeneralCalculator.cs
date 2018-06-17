using System;
using System.Collections.Generic;
using System.Linq;
using SF.Domain.DTO;
using SF.Domain.Services;

namespace SF.Domain.TaxCalculators
{
    public class GeneralCalculator : ITaxCalculator
    {
        private readonly ITaxPercentagesService _taxPercentagesService;

        public GeneralCalculator(ITaxPercentagesService taxPercentagesService)
        {
            _taxPercentagesService = taxPercentagesService ?? throw new ArgumentNullException(nameof(taxPercentagesService));
        }
        public decimal Calculate(TaxCalculationContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            List<IncomeTaxThreshold> incomeTaxThresholds = GetIncomeTaxThreshold();

            var currentValueIncomeTaxThreshold =
                GetCurrentValueIncomeTaxThreshold(context.TotalIncomes, incomeTaxThresholds);

            if (IsLimitValueMonth(currentValueIncomeTaxThreshold, context))
            {
                IncomeTaxThreshold nextThrashold = GetNextIncomeTaxThreshold(incomeTaxThresholds, currentValueIncomeTaxThreshold);
                CalculateLimitValueForFirstMonth(currentValueIncomeTaxThreshold, prevoiusThrashold)
            }

        }

        private IncomeTaxThreshold GetNextIncomeTaxThreshold(List<IncomeTaxThreshold> incomeTaxThresholds,
            IncomeTaxThreshold currenTaxThreshold)
        {

            return incomeTaxThresholds.First(x => x.ThresholdNumber == (currenTaxThreshold.ThresholdNumber + 1))
        }

        private bool IsLimitValueMonth(IncomeTaxThreshold currentValueIncomeTaxThreshold, TaxCalculationContext context)
        {
            var currentIncomesSum = context.TotalIncomes + context.CurrentIncome;
            return currentIncomesSum > currentValueIncomeTaxThreshold.ToAmount &&
                   context.TotalIncomes > currentValueIncomeTaxThreshold.FromAmount;
        }

        private List<IncomeTaxThreshold> GetIncomeTaxThreshold()
        {
            throw new NotImplementedException();
        }

        private IncomeTaxThreshold GetCurrentValueIncomeTaxThreshold(decimal totalIncomes, List<IncomeTaxThreshold> incomeTaxThresholds)
        {
            var retval = incomeTaxThresholds.FirstOrDefault(x => x.FromAmount <= totalIncomes && x.ToAmount < totalIncomes);
            return retval;
        }


    }
}