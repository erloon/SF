using SF.Calculator.Core.DTO;

namespace SF.Calculator.Core.TaxCalculators
{
    public interface ITaxCalculatorStrategy
    {
        decimal Calculate(TaxCalculationContext context);
    }
}