﻿using System;
using System.Collections.Generic;
using SF.Calculator.Core.DTO;
using SF.Shared.Infrastructure;

namespace SF.Calculator.Core.Model
{
    public class YearlySelfEmployeeCalculation : Entity
    {
        public decimal TotalIncomes { get; protected set; }
        public decimal TotalCosts { get; protected set; }

        private decimal _vatTaxeRate = 0.23m;
        private decimal _taxFreeAmount = 46.34m;
        public virtual List<SelfEmployeeCalculation> Calculations { get; protected set; }

        protected YearlySelfEmployeeCalculation() { }
        public YearlySelfEmployeeCalculation(YearlySelfEmployeeCalculationContext context)
        {
            this.Id = Guid.NewGuid();
            this.TotalIncomes = 0m;
            this.TotalCosts = 0m;
            this.Calculations = new List<SelfEmployeeCalculation>();
            Calculate(context);
        }

        private void Calculate(YearlySelfEmployeeCalculationContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            foreach (var monthlyBalanceSheetData in context.MonthlyBalanceSheetData)
            {
                var monthlyContext = CreateMonthlyContext(context, monthlyBalanceSheetData);
                var calculation = new SelfEmployeeCalculation(monthlyContext);

                this.TotalIncomes += calculation.BaseAmount;
                this.TotalCosts += calculation.IncomeCostsAmount;

                this.Calculations.Add(calculation);
            }
        }

        private SelfEmployeeCalculationContext CreateMonthlyContext(YearlySelfEmployeeCalculationContext context, MonthlyBalanceSheetData monthlyBalanceSheetData)
        {
            return new SelfEmployeeCalculationContext()
            {
                Month = monthlyBalanceSheetData.Month,
                BaseAmount = monthlyBalanceSheetData.Salary,
                IsGross = context.IsGross,
                IncomeCost = monthlyBalanceSheetData.IncomeCosts,
                InsuranceContributionContext = context.InsuranceContributionContext,
                IsMedicalInsurance = context.IsMedicalInsurance,
                PreviusMonthsIncome = this.TotalIncomes,
                TaxationForm = context.TaxationForm,
                IncomeTaxAmmount = context.IncomeTaxAmount,
                VatTaxRate = _vatTaxeRate,
                MonthlyTaxFreeAmount = _taxFreeAmount
            };
        }


    }
}