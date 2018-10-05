using System.Collections.Generic;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Core.Services
{
    public interface ITaxPercentagesService
    {
        IncomeTaxThreshold GetLinearRate();
        List<IncomeTaxThreshold> GetGeneralIncomeTaxThresholds();
        List<IncomeTaxThreshold> GetFlatRates();
    }
}