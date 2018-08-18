using SF.Domain.DTO;

namespace SF.Domain.TaxCalculators
{
    public interface ITaxCalculatorStrategy
    {
        decimal Calculate(TaxCalculationContext context);
    }
}