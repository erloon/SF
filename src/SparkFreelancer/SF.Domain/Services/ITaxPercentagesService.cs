using System.Collections.Generic;

namespace SF.Domain.Services
{
    public interface ITaxPercentagesService
    {
        IncomeTaxThreshold GetLinearRate();
        List<IncomeTaxThreshold> GetGeneralIncomeTaxThresholds();
        List<IncomeTaxThreshold> GetFlatRates();
    }
}