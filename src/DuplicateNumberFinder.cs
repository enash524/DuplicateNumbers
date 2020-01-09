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
            var dic = new Dictionary<int, int>();

            if (numbers != null && numbers.Length > 0)
            {
                foreach (var i in numbers)
                {
                    if (dic.ContainsKey(i))
                    {
                        dic[i] += 1;
                    }
                    else
                    {
                        dic.Add(i, 0);
                    }
                }

                var obj = dic.Where(v => v.Value == 0);

                if (obj != null && obj.Any())
                {
                    foreach (var o in obj.Reverse())
                    {
                        dic.Remove(o.Key);
                    }
                }
            }

            return dic;
        }
    }
}
