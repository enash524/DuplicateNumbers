using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace DuplicateNumbers
{
    /// <inheritdoc />
    ///  <summary>
    /// Defines a duplicate number finder
    /// </summary>
    public class DuplicateNumberFinder : IDuplicateNumberFinder
    {
        private readonly ILogger<DuplicateNumberFinder> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateNumberFinder`1"/> class.
        /// </summary>
        /// <param name="logger">DI injected logger</param>
        public DuplicateNumberFinder(ILogger<DuplicateNumberFinder> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public Dictionary<int, int> FindDuplicateNumbers(int[] numbers)
        {
            if (numbers == null)
            {
                _logger.LogError("Collection cannot be null (Parameter 'numbers')");
                throw new ArgumentNullException(nameof(numbers), "Collection cannot be null");
            }

            if (numbers.Length == 0)
            {
                _logger.LogError("Collection cannot be empty (Parameter 'numbers')");
                throw new ArgumentException("Collection cannot be empty", nameof(numbers));
            }

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