using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Moq;
using NUnit.Framework;
using SF.API.Controllers;
using SF.Domain.Commands;
using SF.Domain.DTO.Results;
using SF.Domain.Model;
using SF.Tests.API.Factories;

namespace SF.Tests.API.Controllers
{
    [TestFixture]
    public class CalculationsControllerTest
    {
        private Mock<IMediator> _mediator = null;
        private Mock<IMapper> _mapper = null;

        [SetUp]
        public void SetUp()
        {
            this._mediator = new Mock<IMediator>(MockBehavior.Default);
            this._mapper = new Mock<IMapper>(MockBehavior.Default);
        }

        [Test]
        public async Task MonthlySelfEmployeeCalculation_ShouldReturnResult_Success()
        {
            var controller = new CalculationsController(_mediator.Object, _mapper.Object);
            _mediator.Setup(x => x.Send(It.IsAny<IRequest<SelfEmployeeCalculationResult>>(),
                It.IsAny<CancellationToken>())).Returns(Task.FromResult(new SelfEmployeeCalculationResult()));
            _mapper.Setup(x =>
                x.Map<SelfEmployeeCalculation, SelfEmployeeCalculationResult>(
                    It.IsAny<SelfEmployeeCalculation>())).Returns(new SelfEmployeeCalculationResult());
            var command = SelfEmployeeCalculationCommandFactory.CreateDefault();

            var results = await controller.SelfEmployeeCalculation(command);

            Assert.NotNull(results);


        }
    }
}