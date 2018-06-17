namespace SF.Domain.DTO
{
    public class TaxCalculationContext
    {
        public decimal TotalIncomes { get; protected set; }
        public decimal CurrentIncome { get; protected set; }

        public TaxCalculationContext(decimal totalIncomes, decimal income)
        {
            this.TotalIncomes = totalIncomes;
            this.CurrentIncome = income;
        }
    }
}