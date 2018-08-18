namespace SF.Domain.DTO
{
    public class TaxCalculationContext
    {
        public decimal TotalIncomes { get; protected set; }
        public decimal CurrentIncome { get; protected set; }
        public TaxationForm TaxationForm { get;protected set; }

        public TaxCalculationContext(decimal totalIncomes, decimal income, TaxationForm taxationForm)
        {
            this.TotalIncomes = totalIncomes;
            this.CurrentIncome = income;
            this.TaxationForm = taxationForm;
        }
    }
}