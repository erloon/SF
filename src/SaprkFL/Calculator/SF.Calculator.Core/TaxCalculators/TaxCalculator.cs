using System;
using Autofac;
using SF.Calculator.Core.DTO;
using SF.Shared.Infrastructure;

namespace SF.Calculator.Core.TaxCalculators
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly IComponentContext _componentContext;

        public TaxCalculator(IComponentContext componentContext)
        {
            _componentContext = componentContext ?? throw new ArgumentNullException(nameof(componentContext));
        }

        decimal ITaxCalculator.Calculate(TaxCalculationContext context)
        {
            ITaxCalculatorStrategy calculator = null;
            calculator = _componentContext.ResolveKeyed<ITaxCalculatorStrategy>(context.TaxationForm);

            if (calculator == null) throw new DomainException($"Tax calculator for {context.TaxationForm} not found");

            return calculator.Calculate(context);
        }
    }
}