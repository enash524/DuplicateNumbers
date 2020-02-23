using System;
using System.Collections.Generic;

namespace DuplicateNumbers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                IDuplicateNumberFinder duplicateNumberFinder = new DuplicateNumberFinder();
                Dictionary<int, int> actualDuplicates = duplicateNumberFinder.FindDuplicateNumbers(new[] { 1, 2, 2, 3, 3, 3 });
                bool testPassed = actualDuplicates.ContainsKey(2) &&
                    actualDuplicates[2] == 1 &&
                    actualDuplicates.ContainsKey(3) &&
                    actualDuplicates[3] == 2;

                ConsoleColor previousColor = Console.ForegroundColor;
                Console.ForegroundColor = testPassed ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(testPassed ? "Passed" : "Failed");
                Console.ForegroundColor = previousColor;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            finally
            {
                Console.WriteLine("--- Press Any Key To Continue ---");
                Console.ReadKey();
            }
        }
    }
}
