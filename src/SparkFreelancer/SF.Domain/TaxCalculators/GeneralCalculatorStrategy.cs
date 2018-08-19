using System;
using System.Collections.Generic;
using System.Linq;
using SF.Domain.DTO;
using SF.Domain.Model;
using SF.Domain.Services;

namespace SF.Domain.TaxCalculators
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
                IncomeTaxThreshold nextThrashold = GetNextIncomeTaxThreshold(incomeTaxThresholds, currentValueIncomeTaxThreshold);
                taxValue = CalculateForBorderMonth(context, currentValueIncomeTaxThreshold, nextThrashold);
            }
            else
            {
                taxValue = CalculateForFullMonth(currentValueIncomeTaxThreshold, context);
            }

            return taxValue;
        }

        private decimal CalculateForFullMonth(IncomeTaxThreshold currentValueIncomeTaxThreshold, TaxCalculationContext context)
        {
            return context.CurrentIncome * currentValueIncomeTaxThreshold.Percentage;
        }

        private decimal CalculateForBorderMonth(TaxCalculationContext context, IncomeTaxThreshold currentValueIncomeTaxThreshold, IncomeTaxThreshold nextThrashold)
        {
            decimal taxValue = (currentValueIncomeTaxThreshold.ToAmount - context.TotalIncomes) * currentValueIncomeTaxThreshold.Percentage;
            var remainingValueForNextThreshold =((context.TotalIncomes + context.CurrentIncome) - nextThrashold.FromAmount) * nextThrashold.Percentage;

            return taxValue + remainingValueForNextThreshold;
        }

        private IncomeTaxThreshold GetNextIncomeTaxThreshold(List<IncomeTaxThreshold> incomeTaxThresholds,
            IncomeTaxThreshold currenTaxThreshold)
        {
            return incomeTaxThresholds.FirstOrDefault(x => x.ThresholdNumber == (currenTaxThreshold.ThresholdNumber + 1));
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