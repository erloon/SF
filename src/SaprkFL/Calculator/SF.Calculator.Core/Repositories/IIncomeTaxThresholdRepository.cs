using System.Collections.Generic;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Core.Repositories
{
    public interface IIncomeTaxThresholdRepository
    {
        List<IncomeTaxThreshold> Get(TaxationForm taxationForm);

    }
}