using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SF.Domain.Commands;
using SF.Domain.DTO;
using SF.Domain.Handlers;
using SF.Domain.Model;
using SF.Domain.Services;
using SF.Domain.TaxCalculators;
using SF.Tests.API.Factories;

namespace SF.Test.Domain.Handlers
{
    [TestFixture]
    public class SelfEmployeeCalculationHandlerTest
    {
        private Mock<ITaxCalculator> _taxCalculator = null;
        private Mock<IInsuranceContributionService> _insuranceContributionService = null;
        private SelfEmployeeCalculationHandler _handler = null;

        private InsuranceContributionContext CreateInsuranceContributionContext(SelfEmployeeCalculationCommand command)
        {
            return new InsuranceContributionContext()
            {
                HealthBaseAmount = 3554.93m,
                InsuranceBaseAmount = 2665.8m,
                Percentage = new InsuranceContributionsPercentage()
                {
                    Accident = command.AccidentContributionPercentage,
                    Health = 0.09m,
                    Disabiliti = 0.08m,
                    HealthToDiscount = 0.0775m,
                    LaborFound = 0.0245m,
                    Medical = 0.0245m,
                    Retirement = 0.1952m
                }
            };
        }

        [SetUp]
        public void SetUp()
        {
            _taxCalculator = new Mock<ITaxCalculator>(MockBehavior.Default);
            _insuranceContributionService = new Mock<IInsuranceContributionService>();
            _handler = new SelfEmployeeCalculationHandler(_taxCalculator.Object, _insuranceContributionService.Object);
        }

        [Test]
        public async Task Handle_ShouldCalculateSalary_Success()
        {
            var command = SelfEmployeeCalculationCommandFactory.CreateDefault();
            var context = CreateInsuranceContributionContext(command);

            _insuranceContributionService.Setup(x => x.GetWithDicount(It.IsAny<decimal>(), It.IsAny<bool>()))
                .Returns(context);
            _insuranceContributionService.Setup(x => x.Get(It.IsAny<decimal>(), It.IsAny<bool>()))
                .Returns(context);


           

            var retval = await _handler.Handle(command, CancellationToken.None);

            Assert.NotNull(retval);
        }
    }
}