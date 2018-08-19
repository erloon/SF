using System.Collections.Generic;
using SF.Domain.Model;

namespace SF.Domain.Services
{
    public interface ITaxPercentagesService
    {
        IncomeTaxThreshold GetLinearRate();
        List<IncomeTaxThreshold> GetGeneralIncomeTaxThresholds();
        List<IncomeTaxThreshold> GetFlatRates();
    }
}