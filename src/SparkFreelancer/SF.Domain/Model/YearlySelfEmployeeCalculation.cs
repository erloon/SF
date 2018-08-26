using System;
using System.Collections.Generic;
using SF.Domain.DTO;
using SF.Infrastructure;

namespace SF.Domain.Model
{
    public class YearlySelfEmployeeCalculation : Entity
    {
        public decimal TotalIncomes { get; protected set; }
        public decimal TotalCosts { get; protected set; }

        public List<SelfEmployeeCalculation> Calculations { get; protected set; }

        public YearlySelfEmployeeCalculation()
        {
            this.Id = Guid.NewGuid();
            this.TotalIncomes = 0m;
            this.TotalCosts = 0m;
            this.Calculations = new List<SelfEmployeeCalculation>();
        }

        public void Calculate(YearlySelfEmployeeCalculationContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            for (int i = 1; i <= 12; i++)
            {
                var monthlyContext = CreateMonthlyContext(context, i);
                this.Calculations.Add(new SelfEmployeeCalculation(monthlyContext));
                AddCost(GetMonthValues(context.Costs,i));
                AddIncome(GetMonthValues(context.Incomes,i));
            }
        }

        private SelfEmployeeCalculationContext CreateMonthlyContext(YearlySelfEmployeeCalculationContext context, int i)
        {
            return new SelfEmployeeCalculationContext()
            {
                Month = (Month)i,
                BaseAmount = GetMonthValues(context.Incomes,i),
                IncomeCost = GetMonthValues(context.Costs, i),
                InsuranceContributionContext = context.InsuranceContributionContext,
                IsMedicalInsurance = context.IsMedicalInsurance,
                PreviusMonthsIncome = this.TotalIncomes,
                TaxationForm = context.TaxationForm,


            };
        }

        decimal GetMonthValues(Dictionary<Month, decimal> values, int month)
        {
            decimal income = 0;
            values.TryGetValue((Month)month, out income);
            return income;
        }

        private void AddIncome(decimal income)
        {
            this.TotalIncomes += income;
        }

        private void AddCost(decimal cost)
        {
            this.TotalCosts += cost;
        }

        private decimal GetTaxRate(TaxationForm taxation, decimal baseAmount)
        {
            if (taxation == TaxationForm.GENERAL)
                return GetGeneralTaxRate(baseAmount);
            return GetLinearTaxRate();
        }

        private decimal GetLinearTaxRate()
        {
            return 0.19m;
        }

        private decimal GetGeneralTaxRate(decimal baseAmount)
        {
            if (baseAmount < 85528)
                return 0.18m;
            else return 0.32m;
        }
    }
}