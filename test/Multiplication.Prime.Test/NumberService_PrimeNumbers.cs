using Microsoft.Extensions.Logging;
using Moq;
using Multiplication.Prime.Service;
using Xunit;

namespace Multiplication.Prime.Test
{
    public class NumberService_PrimeNumbers
    {
        private INumberService _numberService;

        private readonly Mock<ILogger<PrimeNumbers>> _mockLogger;

        public NumberService_PrimeNumbers()
        {
            _mockLogger = new Mock<ILogger<PrimeNumbers>>();
        }

        [Fact]
        public void ValidInput_NoCount()
        {
            //Arrange
            _numberService = new PrimeNumbers(_mockLogger.Object);

            //Act
            var output = _numberService.GetValues(1);
    
            //Assert
            Assert.Empty(output);
        }

        [Fact]
        public void ValidInput_ValidCount()
        {
            //Arrange
            _numberService = new PrimeNumbers(_mockLogger.Object);

            //Act
            var output = _numberService.GetValues(10);
    
            //Assert
            Assert.NotEmpty(output);
        }


        
    }
}