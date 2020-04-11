using System.Collections.Generic;

namespace DuplicateNumbers
{
    /// <summary>
    /// Defines the interface for duplicate number finders to implement
    /// </summary>
    public interface IDuplicateNumberFinder
    {
        /// <summary>
        /// Find the duplicate numbers and returns the number of duplicates for each
        /// </summary>
        /// <param name="numbers">The numbers to check</param>
        /// <returns>The mapping of numbers to duplicate counts</returns>
        Dictionary<int, int> FindDuplicateNumbers(int[] numbers);
    }
}