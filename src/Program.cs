using System;

namespace DuplicateNumbers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var duplicateNumberFinder = new DuplicateNumberFinder();
                var actualDuplicates = duplicateNumberFinder.FindDuplicateNumbers(new[] { 1, 2, 2, 3, 3, 3 });
                var testPassed = actualDuplicates.ContainsKey(2) && actualDuplicates[2] == 1
                                                                 && actualDuplicates.ContainsKey(3) &&
                                                                 actualDuplicates[3] == 2;

                Console.ForegroundColor = testPassed ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write(testPassed ? "Passed" : "Failed");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
