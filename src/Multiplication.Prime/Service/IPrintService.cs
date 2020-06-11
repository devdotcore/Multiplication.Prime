using System.Collections.Generic;

namespace Multiplication.Prime.Service
{
    public interface IPrintService
    {
        /// <summary>
        /// Generate final output like 
        ///     - Print to file system
        /// </summary>
        /// <param name="input">Input as string</param>
         void Print(string input);
    }
}