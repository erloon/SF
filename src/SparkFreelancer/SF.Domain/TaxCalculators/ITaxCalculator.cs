using SF.Domain.DTO;

namespace SF.Domain.TaxCalculators
{
    public interface ITaxCalculator
    {
        decimal Calculate(TaxCalculationContext context);
    }
}