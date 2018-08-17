using System;
using System.CodeDom;
using SF.Domain.DTO;
using SF.Infrastructure;

namespace SF.Domain
{
    public class MonthlySelfEmployeeCalculation  : Entity
    {
        public Month Month { get; protected set; }
        public decimal NetPay { get; protected set; }
        public decimal NetPayEstimate { get; protected set; }
        public decimal VatAmount { get; protected set; }
        public decimal IncomeCostsAmount { get; protected set; }
        public decimal TaxBaseAmount { get; protected set; }
        public decimal BaseAmount { get; protected set; }
        public decimal TaxAmount { get; protected set; }
        public decimal TaxDeductions { get; protected set; }
        public decimal TaxRate { get; protected set; }
        public InsuranceContribution InsuranceContribution { get; protected set; }

        public MonthlySelfEmployeeCalculation(MonthlySelfEmployeeCalculationContext calculationContext)
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
            this.Month = calculationContext.Month;

            SetTaxRate(calculationContext);
            CalculateVatAmount(calculationContext.VatRate);
            AddInsuranceContribution(calculationContext.InsuranceContributionContext);
            CalcualteMonthlyBaseAmount(calculationContext);
            CalculateIncomeTax(calculationContext);
            CalculateNetPay(calculationContext);
            CalculateNetPayEstimate(calculationContext);
        }

        private void CalculateVatAmount(decimal vatRate)
        {
            if (vatRate < 0) throw new ArgumentOutOfRangeException(nameof(vatRate));

            if (this.TaxBaseAmount <= 0 || vatRate == 0) this.VatAmount = 0;
            else
                this.VatAmount = this.TaxBaseAmount * vatRate;
        }

        private void AddInsuranceContribution(InsuranceContributionContext insuranceContributionContext)
        {
            this.InsuranceContribution = new InsuranceContribution(insuranceContributionContext);
        }

        private void CalcualteMonthlyBaseAmount(MonthlySelfEmployeeCalculationContext context)
        {
            this.BaseAmount = Math.Round(this.TaxBaseAmount - this.IncomeCostsAmount -
                              this.InsuranceContribution.SocialInsuranceContributionSum(context.IsMedicalInsurance), 0);
        }

        private void CalculateIncomeTax(MonthlySelfEmployeeCalculationContext calculationContext)
        {
            if (this.BaseAmount <= 0)
                this.TaxAmount = 0;
            else
                this.TaxAmount = Math.Round((this.TaxRate * this.BaseAmount) - this.InsuranceContribution.HealthInsuranceDiscount, 0);
        }

        private void CalculateNetPay(MonthlySelfEmployeeCalculationContext context)
        {
            this.NetPay = this.TaxBaseAmount -
                          this.InsuranceContribution.InsuranceContributionsSum(context.IsMedicalInsurance) -
                          this.TaxAmount -
                          this.IncomeCostsAmount;
        }

        private void CalculateNetPayEstimate(MonthlySelfEmployeeCalculationContext context)
        {
            this.NetPayEstimate = this.TaxBaseAmount -
                                  this.InsuranceContribution.InsuranceContributionsSum(context.IsMedicalInsurance) -
                                  this.TaxAmount;
        }

        private void SetTaxRate(MonthlySelfEmployeeCalculationContext context)
        {
            var currentBaseAmount = context.PreviusMonthsIncomes + this.BaseAmount;
            this.TaxRate = context.GetIncomTaxRate.Invoke(context.TaxationForm, currentBaseAmount);
        }
    }
}