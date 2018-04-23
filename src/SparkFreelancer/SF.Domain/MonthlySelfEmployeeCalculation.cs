using System;
using System.CodeDom;
using SF.Domain.DTO;
using SF.Infrastructure;

namespace SF.Domain
{
    public class MonthlySelfEmployeeCalculation : Entity
    {
        public decimal NetPay { get; protected set; }
        public decimal VatAmount { get; protected set; }
        public decimal IncomeCostsAmount { get; protected set; }
        public decimal TaxBaseAmount { get; protected set; }
        public decimal BaseAmount { get; set; }
        public decimal TaxAmount { get; protected set; }
        public decimal TaxDeductions { get; protected set; }
        public InsuranceContribution InsuranceContribution { get; protected set; }

        public MonthlySelfEmployeeCalculation(SelfEmployeeCalculationContext calculationContext)
        {
            if (calculationContext.BaseAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(calculationContext.BaseAmount));
            if (calculationContext.IncomeCost < 0)
                throw new ArgumentOutOfRangeException(nameof(calculationContext.IncomeCost));
            if (calculationContext.VatRate < 0)
                throw new ArgumentOutOfRangeException(nameof(calculationContext.VatRate));

            this.Id = Guid.NewGuid();
            this.TaxBaseAmount = calculationContext.BaseAmount;
            this.IncomeCostsAmount = calculationContext.IncomeCost;
            CalculateVatAmount(calculationContext.VatRate);
            AddInsuranceContribution(calculationContext.InsuranceContributionContext);
            CalcualteMonthlyBaseAmount(calculationContext);
            CalculateIncomeTax(calculationContext);
        }

        private void CalculateVatAmount(decimal vatRate)
        {
            if (vatRate < 0) throw new ArgumentOutOfRangeException(nameof(vatRate));

            if (this.TaxBaseAmount <= 0 || vatRate == 0) this.VatAmount = 0;

            this.VatAmount = this.TaxBaseAmount * vatRate;
        }

        private void AddInsuranceContribution(InsuranceContributionContext insuranceContributionContext)
        {
            this.InsuranceContribution = new InsuranceContribution(insuranceContributionContext);
        }

        private void CalcualteMonthlyBaseAmount(SelfEmployeeCalculationContext context)
        {
            this.BaseAmount = this.TaxBaseAmount - this.IncomeCostsAmount -
                              this.InsuranceContribution.InsuranceContributionsSum(context.IsMedicalInsurance);
        }

        private void CalculateIncomeTax(SelfEmployeeCalculationContext calculationContext)
        {
            var currentBaseAmount = calculationContext.PreviusMonthsIncomes + this.BaseAmount;
            var taxRate = calculationContext.GetIncomTaxRate.Invoke(calculationContext.TaxationForm, currentBaseAmount);

            this.TaxAmount = taxRate * this.BaseAmount;
        }
    }
}