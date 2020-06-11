using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Multiplication.Prime.Controllers;
using Multiplication.Prime.Service;
using Xunit;
using static Multiplication.Prime.Model.ApplicationModel;

namespace Multiplication.Prime.Test
{
    public class ApplicationController_IsInput
    {
        private ApplicationController _applicationController;

        private readonly Mock<ILogger<ApplicationController>> _mockLogger;

        private Mock<IApplicationService> _mockApplicationService;

        public ApplicationController_IsInput()
        {
            _mockLogger = new Mock<ILogger<ApplicationController>>();

            _mockApplicationService = new Mock<IApplicationService>();
        }

        [Fact]
        public void Invalid_Return400()
        {
            //Arrange
            _applicationController = new ApplicationController(_mockLogger.Object, _mockApplicationService.Object);

            //Act
            var output = _applicationController.GetAction(0);
            var status = output.Result as ObjectResult;

            //Assert
            Assert.Equal(400, status.StatusCode);
        }

        [Fact]
        public void Valid_Return201()
        {
            //Arrange
            _mockApplicationService.Setup(s => s.Process(It.IsAny<long>())).Returns(ServiceCode.SUCCESS);
            _applicationController = new ApplicationController(_mockLogger.Object, _mockApplicationService.Object);

            //Act
            var output = _applicationController.GetAction(10);
            var status = output.Result as ObjectResult;

            //Assert
            Assert.Equal(201, status.StatusCode);
        }

        [Fact]
        public void Valid_Return400()
        {
            //Arrange
            _mockApplicationService.Setup(s => s.Process(It.IsAny<long>())).Returns(ServiceCode.INVALID_INPUT);
            _applicationController = new ApplicationController(_mockLogger.Object, _mockApplicationService.Object);

            //Act
            var output = _applicationController.GetAction(10);
            var status = output.Result as ObjectResult;

            //Assert
            Assert.Equal(400, status.StatusCode);
        }

        [Fact]
        public void Valid_Return500()
        {
            //Arrange
            _mockApplicationService.Setup(s => s.Process(It.IsAny<long>())).Returns(ServiceCode.SYSTEM_ERROR);
            _applicationController = new ApplicationController(_mockLogger.Object, _mockApplicationService.Object);

            //Act
            var output = _applicationController.GetAction(10);
            var status = output.Result as ObjectResult;

            //Assert
            Assert.Equal(500, status.StatusCode);
        }

    }
}