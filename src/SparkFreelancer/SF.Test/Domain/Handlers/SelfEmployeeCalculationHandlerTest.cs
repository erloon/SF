using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SF.Domain.Handlers;
using SF.Domain.TaxCalculators;
using SF.Tests.API.Factories;

namespace SF.Test.Domain.Handlers
{
    [TestFixture]
    public class SelfEmployeeCalculationHandlerTest
    {
        private Mock<ITaxCalculator> _taxCalculator = null;
        private SelfEmployeeCalculationHandler _handler = null;

        [SetUp]
        public void SetUp()
        {
            _taxCalculator = new Mock<ITaxCalculator>(MockBehavior.Default);
            _handler = new SelfEmployeeCalculationHandler(_taxCalculator.Object);
        }

        [Test]
        public async Task Handle_ShouldCalculateSalary_Success()
        {
            var command = MonthlySelfEmployeeCalculationCommandFactory.CreateDefault();

            var retval = await _handler.Handle(command, CancellationToken.None);

            Assert.NotNull(retval);
        }
    }
}