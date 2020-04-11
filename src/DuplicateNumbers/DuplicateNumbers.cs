using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace DuplicateNumbers
{
    public class DuplicateNumbers
    {
        private readonly IDuplicateNumberFinder _duplicateNumberFinder;
        private readonly ILogger<DuplicateNumbers> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateNumbers`1"/> class.
        /// </summary>
        /// <param name="duplicateNumberFinder">DI injected duplicate number finder implementation</param>
        /// <param name="logger">DI injected logger</param>
        public DuplicateNumbers(IDuplicateNumberFinder duplicateNumberFinder, ILogger<DuplicateNumbers> logger)
        {
            _duplicateNumberFinder = duplicateNumberFinder;
            _logger = logger;
        }

        /// <summary>
        /// Run the program
        /// </summary>
        public void Run()
        {
            try
            {
                Dictionary<int, int> actualDuplicates = _duplicateNumberFinder.FindDuplicateNumbers(new int[6] { 1, 2, 2, 3, 3, 3 });
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
                _logger.LogError(ex, ex.Message);
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