using System;
using Autofac;
using SF.Domain.DTO;
using SF.Infrastructure;

namespace SF.Domain.TaxCalculators
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
            var calculator = _componentContext.ResolveKeyed<ITaxCalculatorStrategy>(context.TaxationForm);

            if (calculator == null) throw new DomainException($"Tax calculator for {context.TaxationForm} not found");

            return calculator.Calculate(context);
        }
    }
}