using System;
using SF.Calculator.Core.DTO;
using SF.Shared.Infrastructure;

namespace SF.Calculator.Core.Model
{
    public class SelfEmployeeCalculation : Entity
    {
        public Month Month { get; protected set; }
        public decimal NetPay { get; protected set; }
        public decimal NetPayEstimate { get; protected set; }
        public decimal VatAmount { get; protected set; }
        public decimal IncomeCostsAmount { get; protected set; }
        public decimal TaxBaseAmount { get; protected set; }
        public decimal BaseAmount { get; protected set; }
        public decimal TaxAmount { get; protected set; }
        private decimal _vatTaxeRate = 0.23m;
        private decimal _taxFreeAmount = 46.34m;
        public InsuranceContribution InsuranceContribution { get; protected set; }

        protected SelfEmployeeCalculation(){}

        public SelfEmployeeCalculation(SelfEmployeeCalculationContext calculationContext)
        {
            if (calculationContext == null) throw new ArgumentNullException(nameof(calculationContext));
            if (calculationContext.BaseAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(calculationContext.BaseAmount));
            if (calculationContext.IncomeCost < 0)
                throw new ArgumentOutOfRangeException(nameof(calculationContext.IncomeCost));

            this.Id = Guid.NewGuid();
            CalculateVatAmount(calculationContext);

            this.TaxBaseAmount = CalculateTaxBaseAmount(calculationContext.BaseAmount,calculationContext.IsGross);
            this.IncomeCostsAmount = calculationContext.IncomeCost;
            this.Month = calculationContext.Month;

            AddInsuranceContribution(calculationContext.InsuranceContributionContext);
            CalculateMonthlyBaseAmount(calculationContext);
            CalculateIncomeTax(calculationContext);
            CalculateNetPay(calculationContext);
            CalculateNetPayEstimate(calculationContext);
        }

        private decimal CalculateTaxBaseAmount(decimal baseAmount, bool isGross)
        {
            if (isGross)
                return baseAmount - VatAmount;
            return baseAmount;
        }
        private void CalculateVatAmount(SelfEmployeeCalculationContext calculationContext)
        {
            //TODO Add vat rate to command and context
            if (calculationContext.IsGross)
                this.VatAmount = Math.Round((calculationContext.BaseAmount - (calculationContext.BaseAmount / (1 + calculationContext.VatTaxRate))), 2);
            else
                this.VatAmount = Math.Round((calculationContext.BaseAmount * calculationContext.VatTaxRate), 2);
        }

        private void AddInsuranceContribution(InsuranceContributionContext insuranceContributionContext)
        {
            this.InsuranceContribution = new InsuranceContribution(insuranceContributionContext);
        }

        private void CalculateMonthlyBaseAmount(SelfEmployeeCalculationContext context)
        {
            this.BaseAmount = Math.Round(this.TaxBaseAmount - this.IncomeCostsAmount -
                              this.InsuranceContribution.SocialInsuranceContributionSum(), 0);
        }

        private void CalculateIncomeTax(SelfEmployeeCalculationContext calculationContext)
        {
            if (this.BaseAmount <= 0)
                this.TaxAmount = 0;
            else
            {
                if (calculationContext.TaxationForm == TaxationForm.LINEAR) calculationContext.MonthlyTaxFreeAmount = 0;
                this.TaxAmount = Math.Round(calculationContext.IncomeTaxAmmount.Invoke(CreateTaxCalculationContext(calculationContext)) - (this.InsuranceContribution.HealthInsuranceDiscount + calculationContext.MonthlyTaxFreeAmount), 0);
            }
        }

        private TaxCalculationContext CreateTaxCalculationContext(SelfEmployeeCalculationContext calculationContext)
        {
            return new TaxCalculationContext(calculationContext.PreviusMonthsIncome, this.BaseAmount, calculationContext.TaxationForm);
        }

        private void CalculateNetPay(SelfEmployeeCalculationContext context)
        {
            this.NetPay = this.TaxBaseAmount -
                          this.InsuranceContribution.InsuranceContributionsSum() -
                          this.TaxAmount -
                          this.IncomeCostsAmount;
        }

        private void CalculateNetPayEstimate(SelfEmployeeCalculationContext context)
        {
            this.NetPayEstimate = this.TaxBaseAmount -
                                  this.InsuranceContribution.InsuranceContributionsSum() -
                                  this.TaxAmount;
        }
    }
}