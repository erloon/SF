﻿using System;
using SF.Domain.DTO;
using SF.Infrastructure;

namespace SF.Domain.Model
{
    public class InsuranceContribution : Entity
    {
        public decimal InsuranceBaseAmount { get; protected set; } // Podstawa wymiaru skladek
        public decimal HealthBaseAmount { get; protected set; } // kwota bazowa dla skladki zdrowotnej 
        public decimal HealthInsurance { get; protected set; } // zdrowotne
        public decimal HealthInsuranceDiscount { get; protected set; } // zdrowotne do us
        public decimal MedicalInsurance { get; protected set; } // Chorobowe
        public decimal DisabilitiInsurance { get; protected set; } // rentowe
        public decimal RetirementInsurance { get; protected set; } // emerytalne
        public decimal AccidentInsurance { get; protected set; } //wypadkowe
        public decimal LaborFoundInsurance { get; protected set; } // Składka na fundusz pracy
        public bool WithMedicalInsurance { get; protected set; }

        protected InsuranceContribution() { }
        public InsuranceContribution(InsuranceContributionContext contributionContext)
        {
            if (contributionContext.InsuranceBaseAmount <= 0) throw new ArgumentOutOfRangeException(nameof(contributionContext.InsuranceBaseAmount));
            if (contributionContext.HealthBaseAmount <= 0) throw new ArgumentOutOfRangeException(nameof(contributionContext.HealthBaseAmount));
            if (contributionContext.Percentage == null) throw new ArgumentNullException(nameof(contributionContext.Percentage));

            this.Id = Guid.NewGuid();
            this.WithMedicalInsurance = contributionContext.IsMedicalInsurance;
            this.InsuranceBaseAmount = contributionContext.InsuranceBaseAmount;
            this.HealthBaseAmount = contributionContext.HealthBaseAmount;

            CalculateInsuranceParts(contributionContext.Percentage);
        }

        public decimal InsuranceContributionsSum()
        {
            var baseContributionSum = (HealthInsurance + DisabilitiInsurance + RetirementInsurance + AccidentInsurance + LaborFoundInsurance + MedicalInsurance);

            return Math.Round(baseContributionSum, 2);
        }

        public decimal SocialInsuranceContributionSum()
        {
            var baseContributionSum = (DisabilitiInsurance + RetirementInsurance + AccidentInsurance + LaborFoundInsurance + MedicalInsurance);

            return Math.Round(baseContributionSum, 2);
        }



        private void CalculateInsuranceParts(InsuranceContributionsPercentage insuranceContributionsPercentage)
        {
            CalculateHealthInsurance(insuranceContributionsPercentage, this.HealthBaseAmount);
            CalculateDisabilitiInsurance(insuranceContributionsPercentage.Disabiliti, this.InsuranceBaseAmount);
            CalculateRetirementInsurance(insuranceContributionsPercentage.Retirement, this.InsuranceBaseAmount);
            CalculateAccidentInsurance(insuranceContributionsPercentage.Accident, this.InsuranceBaseAmount);
            CalculatLaborFoundInsurance(insuranceContributionsPercentage.LaborFound, this.InsuranceBaseAmount);

            if (this.WithMedicalInsurance) CalculateMedicalInsurance(insuranceContributionsPercentage.Medical, this.InsuranceBaseAmount);

        }

        private void CalculatLaborFoundInsurance(decimal laborFound, decimal insuranceBaseAmount)
        {
            this.LaborFoundInsurance = CalculateInsurance(laborFound, insuranceBaseAmount);
        }

        private void CalculateAccidentInsurance(decimal accident, decimal insuranceBaseAmount)
        {
            this.AccidentInsurance = CalculateInsurance(accident, insuranceBaseAmount);
        }

        private void CalculateRetirementInsurance(decimal retirement, decimal insuranceBaseAmount)
        {
            this.RetirementInsurance = CalculateInsurance(retirement, insuranceBaseAmount);
        }

        private void CalculateDisabilitiInsurance(decimal disabiliti, decimal insuranceBaseAmount)
        {
            this.DisabilitiInsurance = CalculateInsurance(disabiliti, insuranceBaseAmount);
        }

        private void CalculateMedicalInsurance(decimal medical, decimal insuranceBaseAmount)
        {
            this.MedicalInsurance = CalculateInsurance(medical, insuranceBaseAmount);
        }

        private void CalculateHealthInsurance(InsuranceContributionsPercentage insuranceContributionsPercentage, decimal healthBaseAmount)
        {
            this.HealthInsurance = CalculateInsurance(insuranceContributionsPercentage.Health, healthBaseAmount);
            this.HealthInsuranceDiscount = CalculateInsurance(insuranceContributionsPercentage.HealthToDiscount, healthBaseAmount);
        }

        private decimal CalculateInsurance(decimal percentage, decimal baseAmount)
        {
            return Math.Round((percentage * baseAmount), 2);
        }

    }
}