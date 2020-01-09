using System.Collections.Generic;
using System.Linq;

namespace DuplicateNumbers
{
    /// <inheritdoc />
    ///  <summary>
    /// Defines a duplicate number finder
    /// </summary>
    internal class DuplicateNumberFinder : IDuplicateNumberFinder
    {
        /// <inheritdoc />
        public Dictionary<int, int> FindDuplicateNumbers(int[] numbers)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();

            if (numbers != null && numbers.Length > 0)
            {
                dic = numbers
                    .GroupBy(n => n)
                    .Select(g => new
                    {
                        g.Key,
                        Value = g.Count() - 1
                    })
                    .Where(g => g.Value > 0)
                    .ToDictionary(d => d.Key, d => d.Value);
            }

            return dic;
        }
    }
}
