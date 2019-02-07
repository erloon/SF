using System;
using System.Collections.Generic;
using System.Linq;
using SF.Calculator.Core.DTO;
using SF.Calculator.Core.Model;
using SF.Calculator.Core.Services;

namespace SF.Calculator.Core.TaxCalculators
{
    public class GeneralCalculatorStrategy : ITaxCalculatorStrategy
    {
        private readonly ITaxPercentagesService _taxPercentagesService;

        public GeneralCalculatorStrategy(ITaxPercentagesService taxPercentagesService)
        {
            _taxPercentagesService = taxPercentagesService ?? throw new ArgumentNullException(nameof(taxPercentagesService));
        }
        public decimal Calculate(TaxCalculationContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            decimal taxValue = 0;
            List<IncomeTaxThreshold> incomeTaxThresholds = GetIncomeTaxThreshold();

            var currentValueIncomeTaxThreshold =
                GetCurrentValueIncomeTaxThreshold(context, incomeTaxThresholds);

            if (IsLimitValueMonth(currentValueIncomeTaxThreshold, context))
            {
                IncomeTaxThreshold nextThreshold = GetNextIncomeTaxThreshold(incomeTaxThresholds, currentValueIncomeTaxThreshold);
                taxValue = CalculateForBorderMonth(context, currentValueIncomeTaxThreshold, nextThreshold);
            }
            else
            {
                taxValue = CalculateForFullMonth(currentValueIncomeTaxThreshold, context);
            }

            return Decimal.Round(taxValue,2);
        }

        private decimal CalculateForFullMonth(IncomeTaxThreshold currentValueIncomeTaxThreshold, TaxCalculationContext context)
        {
            return context.CurrentIncome * currentValueIncomeTaxThreshold.Percentage;
        }

        private decimal CalculateForBorderMonth(TaxCalculationContext context, IncomeTaxThreshold currentValueIncomeTaxThreshold, IncomeTaxThreshold nextThreshold)
        {
            decimal taxValue = (currentValueIncomeTaxThreshold.ToAmount - context.TotalIncomes) * currentValueIncomeTaxThreshold.Percentage;
            var remainingValueForNextThreshold =((context.TotalIncomes + context.CurrentIncome) - nextThreshold.FromAmount) * nextThreshold.Percentage;

            return taxValue + remainingValueForNextThreshold;
        }

        private IncomeTaxThreshold GetNextIncomeTaxThreshold(List<IncomeTaxThreshold> incomeTaxThresholds,
            IncomeTaxThreshold currentTaxThreshold)
        {
            return incomeTaxThresholds.FirstOrDefault(x => x.ThresholdNumber == (currentTaxThreshold.ThresholdNumber + 1));
        }

        private bool IsLimitValueMonth(IncomeTaxThreshold currentValueIncomeTaxThreshold, TaxCalculationContext context)
        {
            var currentIncomesSum = context.TotalIncomes + context.CurrentIncome;
            return currentIncomesSum > currentValueIncomeTaxThreshold.ToAmount
                   && context.TotalIncomes > currentValueIncomeTaxThreshold.FromAmount;
        }

        private List<IncomeTaxThreshold> GetIncomeTaxThreshold()
        {
            return _taxPercentagesService.GetGeneralIncomeTaxThresholds();
        }

        private IncomeTaxThreshold GetCurrentValueIncomeTaxThreshold(TaxCalculationContext context, List<IncomeTaxThreshold> incomeTaxThresholds)
        {
            var value = (context.TotalIncomes + context.CurrentIncome);
            var retval = incomeTaxThresholds.FirstOrDefault(x => x.FromAmount <= context.TotalIncomes && x.ToAmount >= value || x.ToAmount >= context.TotalIncomes);
            return retval;
        }


    }
}