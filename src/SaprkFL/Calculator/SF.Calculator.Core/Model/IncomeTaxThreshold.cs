﻿using System;
using SF.Shared.Infrastructure;

namespace SF.Calculator.Core.Model
{
    public class IncomeTaxThreshold : Entity
    {
        public TaxationForm TaxationForm { get; protected set; }
        public int ThresholdNumber { get; protected set; }
        public decimal FromAmount { get; protected set; }
        public decimal ToAmount { get; protected set; }
        public decimal Percentage { get; protected set; }
        public decimal PreviusMaxTaxValue
        {
            get => ToAmount * Percentage;
            protected set => PreviusMaxTaxValue = value;
        }
        protected IncomeTaxThreshold()
        {
        }
        public IncomeTaxThreshold(TaxationForm taxationForm, int thresholdNumber, decimal fromAmount, decimal toAmount, decimal percentage)
        {
            this.Id = Guid.NewGuid();
            TaxationForm = taxationForm;
            ThresholdNumber = thresholdNumber;
            FromAmount = fromAmount;
            ToAmount = toAmount;
            Percentage = percentage;
        }
    }
}