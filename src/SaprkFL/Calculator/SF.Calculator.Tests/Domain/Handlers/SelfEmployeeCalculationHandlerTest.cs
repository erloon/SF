using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SF.Calculator.Core.Commands;
using SF.Calculator.Core.DTO;
using SF.Calculator.Core.Handlers;
using SF.Calculator.Core.Model;
using SF.Calculator.Core.Repositories;
using SF.Calculator.Core.Services;
using SF.Calculator.Core.TaxCalculators;
using SF.Calculator.Tests.Factories;

namespace SF.Calculator.Tests.Domain.Handlers
{
    [TestFixture]
    public class SelfEmployeeCalculationHandlerTest
    {
        private Mock<ITaxCalculator> _taxCalculator = null;
        private Mock<IInsuranceContributionService> _insuranceContributionService = null;
        private Mock<IBaseValuesDictionaryRepository> _baseValuesDictionaryRepository = null;
        private const string VATKEY = "VATTaxRate";
        private const string MONTHLYTAXFREEAMOUNTKEY = "MonthlyTaxFreeAmount";

        private SelfEmployeeCalculationHandler _handler = null;

        private InsuranceContributionContext CreateInsuranceContributionContext(SelfEmployeeCalculationCommand command)
        {
            return new InsuranceContributionContext()
            {
                HealthBaseAmount = 3554.93m,
                InsuranceBaseAmount = 2665.8m,
                Percentage =  new InsuranceContributionsPercentage(0,0.09m,0.1952m,0.0775m,0.08m, 0.0245m,0.0245m,true)
              
            };
        }

        [SetUp]
        public void SetUp()
        {
            _taxCalculator = new Mock<ITaxCalculator>(MockBehavior.Default);
            _insuranceContributionService = new Mock<IInsuranceContributionService>();
            _baseValuesDictionaryRepository = new Mock<IBaseValuesDictionaryRepository>();
             _baseValuesDictionaryRepository.Setup(x=>x.Get(VATKEY)).Returns(new BaseValuesDictionary(VATKEY,"0.23"));
            _baseValuesDictionaryRepository.Setup(x=>x.Get(MONTHLYTAXFREEAMOUNTKEY)).Returns(new BaseValuesDictionary(MONTHLYTAXFREEAMOUNTKEY,"46.34"));
            _handler = new SelfEmployeeCalculationHandler(_taxCalculator.Object, _insuranceContributionService.Object, _baseValuesDictionaryRepository.Object);
        }

        [Test]
        public async Task Handle_ShouldCalculateSalary_Success()
        {
            var command = SelfEmployeeCalculationCommandFactory.CreateDefault();
            var context = CreateInsuranceContributionContext(command);

            _insuranceContributionService.Setup(x => x.GetWithDiscount(It.IsAny<decimal>(), It.IsAny<bool>()))
                .Returns(context);
            _insuranceContributionService.Setup(x => x.Get(It.IsAny<decimal>(), It.IsAny<bool>()))
                .Returns(context);
            _insuranceContributionService.Setup(x =>
                    x.Create(It.IsAny<InsuranceContributionForm>(), It.IsAny<decimal>(), It.IsAny<bool>()))
                .Returns(context);


           

            var retval = await _handler.Handle(command, CancellationToken.None);

            Assert.NotNull(retval);
        }
    }
}