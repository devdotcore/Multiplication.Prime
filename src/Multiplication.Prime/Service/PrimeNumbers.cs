using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Multiplication.Prime.Service
{
    public class PrimeNumbers : INumberService
    {
        /// <summary>
        /// Logger
        /// </summary>
        private ILogger<PrimeNumbers> _logger;

        /// <summary>
        /// Initialize a new instance of Prime Numbers class
        /// </summary>
        /// <param name="logger"></param>
        public PrimeNumbers(ILogger<PrimeNumbers> logger) => _logger = logger;


        /// <summary>
        /// Find all the prime numbers in the provided input
        /// </summary>
        /// <param name="input">Long Int</param>
        /// <returns>List of Prime Numbers</returns>
        public List<long> GetValues(long input)
        {
            _logger.LogInformation("Looking for prime numbers...");

            List<long> primeNumbers = new List<long>();

            for (long i = 2; i <= input; i++)
            {
                bool isPrime = true;
                for (long j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime)
                {
                    primeNumbers.Add(i);
                }
            }

            _logger.LogInformation($"Returning prime numbers, found - {primeNumbers.Count} prime number(s)");

            return primeNumbers;
        }
    }
}