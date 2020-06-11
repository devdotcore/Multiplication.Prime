using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using Multiplication.Prime.Service;
using Xunit;

namespace Multiplication.Prime.Test
{
    public class OperatorService_Multiply
    {
        private IOperatorService _operatorService;

        private readonly Mock<ILogger<Multiply>> _mockLogger;

        public OperatorService_Multiply()
        {
            _mockLogger = new Mock<ILogger<Multiply>>();
        }

        [Fact]
        public void ValidInput_TableNotGenerated()
        {
            //Arrange
            _operatorService = new Multiply(_mockLogger.Object);

            //Act
            var output = _operatorService.Execute(new List<long>{});
    
            //Assert
            Assert.Null(output);
        }

        [Fact]
        public void ValidInput_TableGenerated()
        {
            //Arrange
            _operatorService = new Multiply(_mockLogger.Object);

            //Act
            var output = _operatorService.Execute(new List<long>{ 2 });
    
            //Assert
            Assert.Contains("4", output);
            Assert.Contains("6", output);
            Assert.Contains("8", output);
            Assert.Contains("20", output);
        }

    }
}