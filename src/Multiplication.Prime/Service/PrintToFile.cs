using System.Collections.Generic;
using System.IO;

namespace Multiplication.Prime.Service
{
    public class PrintToFile : IPrintService
    {
        /// <summary>
        /// Print input to output file
        /// </summary>
        /// <param name="input"></param>
        public void Print(string input)
        {
            using (StreamWriter file = new StreamWriter("Out/output.txt"))
            {
                file.WriteLine(input);
            }
        }
    }
}