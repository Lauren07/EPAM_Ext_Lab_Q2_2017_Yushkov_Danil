using System.Collections.Generic;
using System.Linq;

namespace Task01
{
    internal class Program
    {
        private static string[] Sort(string[] strs, IComparer<string> comparer)
        {
            return strs.OrderBy(str => str, comparer)
                       .ToArray();
        }

        private static int CompareStrings(string x, string y)
        {
            if (x.Length == y.Length)
            {
                return x.CompareTo(y);
            }

            return x.Length > y.Length ? 1 : -1;
        }

        private static void Main(string[] args)
        {
            var comparer = new StringComparer(CompareStrings);
            var strs = new[] { "ba", "aa", "fb", "y", "aaaa", "a" };
            var sortedArray = Sort(strs, comparer);
        }
    }
}
