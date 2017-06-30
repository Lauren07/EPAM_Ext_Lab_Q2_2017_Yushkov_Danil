using System.Collections.Generic;
using System.Linq;

namespace Task03
{
    public delegate bool ConditionSearch(int element);

    public class Finder
    {
        public IEnumerable<int> FindPositiveNumbers(int[] array)
        {
            var result = new List<int>();
            foreach (var element in array)
            {
                if (element > 0)
                {
                    result.Add(element);
                }
            }

            return result;
        }

        public IEnumerable<int> FindPositiveNumbers(int[] array, ConditionSearch condition)
        {
            var result = new List<int>();
            foreach (var element in array)
            {
                if (condition(element))
                {
                    result.Add(element);
                }
            }

            return result;
        }

        public IEnumerable<int> FindPositiveNumbersLinq(int[] array)
        {
            return array.Where(element => element > 0);
        }
    }
}
