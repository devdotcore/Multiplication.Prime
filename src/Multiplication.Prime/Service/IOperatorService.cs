using System.Collections.Generic;

namespace Multiplication.Prime.Service
{
    public interface IOperatorService
    {
        /// <summary>
        /// Permform set operation on the the input like 
        ///     - Multiplication
        /// </summary>
        /// <param name="input">List of numbers</param>
        /// <returns>Grid of multiplication table in the form of grid</returns>
         string Execute(List<long> input);
    }
}