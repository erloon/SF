using SF.Calculator.Core.DTO;

namespace SF.Calculator.Core.TaxCalculators
{
    public interface ITaxCalculator
    {
        decimal Calculate(TaxCalculationContext context);
    }
}