using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using Multiplication.Prime.Service;
using Xunit;
using static Multiplication.Prime.Model.ApplicationModel;

namespace Multiplication.Prime.Test
{
    public class ApplicationService_IsInput
    {
        private IApplicationService _applicationService;

        private readonly Mock<ILogger<ApplicationService>> _mockLogger;

        private readonly Mock<IOperatorService> _mockOperatorService;

        private readonly Mock<INumberService> _mockNumberService;

        private readonly Mock<IPrintService> _mockPrintService;

        public ApplicationService_IsInput()
        {
            _mockLogger = new Mock<ILogger<ApplicationService>>();

            _mockOperatorService = new Mock<IOperatorService>();
            _mockNumberService = new Mock<INumberService>();
            _mockPrintService = new Mock<IPrintService>();
        }

        [Fact]
        public void Invalid_ServiceCode_2()
        {
            //Arrange
            _applicationService = new ApplicationService(_mockLogger.Object,
                                                         _mockNumberService.Object,
                                                         _mockOperatorService.Object,
                                                         _mockPrintService.Object);

            //Act
            var output = _applicationService.Process(0);

            //Assert
            Assert.Equal(ServiceCode.SYSTEM_ERROR, output);
        }


        [Fact]
        public void Invalid_ServiceCode_1()
        {
            //Arrange
            _mockNumberService.Setup(n => n.GetValues(It.IsAny<long>())).Returns(new List<long>());

            _applicationService = new ApplicationService(_mockLogger.Object,
                                                         _mockNumberService.Object,
                                                         _mockOperatorService.Object,
                                                         _mockPrintService.Object);

            //Act
            var output = _applicationService.Process(0);

            //Assert
            Assert.Equal(ServiceCode.INVALID_INPUT, output);
        }

        [Fact]
        public void Valid_ServiceCode_0()
        {
            //Arrange
            _mockNumberService.Setup(n => n.GetValues(It.IsAny<long>())).Returns(new List<long>{2});
            _mockOperatorService.Setup(o => o.Execute(It.IsAny<List<long>>())).Returns("2 4 6 8 10 12 14 16 18 20");

            _applicationService = new ApplicationService(_mockLogger.Object,
                                                         _mockNumberService.Object,
                                                         _mockOperatorService.Object,
                                                         _mockPrintService.Object);

            //Act
            var output = _applicationService.Process(2);

            //Assert
            Assert.Equal(ServiceCode.SUCCESS, output);
        }

        [Fact]
        public void ValidInput_ServiceCode_3()
        {
            //Arrange
            _mockNumberService.Setup(n => n.GetValues(It.IsAny<long>())).Returns(new List<long>{2});
            _mockOperatorService.Setup(o => o.Execute(It.IsAny<List<long>>())).Returns("");

            _applicationService = new ApplicationService(_mockLogger.Object,
                                                         _mockNumberService.Object,
                                                         _mockOperatorService.Object,
                                                         _mockPrintService.Object);

            //Act
            var output = _applicationService.Process(2);

            //Assert
            Assert.Equal(ServiceCode.APPLICATION_ERROR, output);
        }

    }
}