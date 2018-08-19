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
            _mediator.Setup(x => x.Send(It.IsAny<IRequest<MonthlySelfEmployeeCalculationResult>>(),
                It.IsAny<CancellationToken>())).Returns(Task.FromResult(new MonthlySelfEmployeeCalculationResult()));
            _mapper.Setup(x =>
                x.Map<MonthlySelfEmployeeCalculation, MonthlySelfEmployeeCalculationResult>(
                    It.IsAny<MonthlySelfEmployeeCalculation>())).Returns(new MonthlySelfEmployeeCalculationResult());
            var command = MonthlySelfEmployeeCalculationCommandFactory.CreateDefault();

            var results = await controller.MonthlySelfEmployeeCalculation(command);

            Assert.NotNull(results);


        }
    }
}