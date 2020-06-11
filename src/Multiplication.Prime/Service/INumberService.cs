using System.Collections.Generic;

namespace Multiplication.Prime.Service
{
    public interface INumberService
    {
        /// <summary>
        /// Perform Number related operations 
        ///     - Find Prime Numbers
        /// </summary>
        /// <param name="input">Long Int</param>
        /// <returns>Expected List of Numbers</returns>
         List<long> GetValues(long input);
    }
}