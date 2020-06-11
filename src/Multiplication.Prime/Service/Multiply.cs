using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Multiplication.Prime.Service
{
    public class Multiply : IOperatorService
    {
        /// <summary>
        /// Logger
        /// </summary>
        private ILogger<Multiply> _logger;

        /// <summary>
        /// Initialize a new instance of Multiply class
        /// </summary>
        /// <param name="logger"></param>
        public Multiply(ILogger<Multiply> logger) => _logger = logger;

        /// <summary>
        /// Generate Multiplication table for the input numbers.
        /// </summary>
        /// <param name="input">List of numbers</param>
        /// <returns>grid of multiplication table</returns>
        public string Execute(List<long> input)
        {
            if(input.Count == 0)
                return null;

            _logger.LogInformation("Generating multiplication table...");

            StringBuilder multiplicationTable = new StringBuilder();

            multiplicationTable.AppendFormat("{0,4}", "*");

            foreach (long number in input)
                multiplicationTable.AppendFormat("{0,4}", number.ToString());

            multiplicationTable.AppendLine();

            for (int i = 1; i <= 10; i++)
            {
                multiplicationTable.AppendFormat("{0,4}", (i).ToString());

                foreach (long number in input)
                {
                    multiplicationTable.AppendFormat("{0,4}", (number * i).ToString());
                }
                multiplicationTable.AppendLine();
            }

            _logger.LogInformation("Multiplication table grid Generated");

            return multiplicationTable.ToString();
        }
    }
}