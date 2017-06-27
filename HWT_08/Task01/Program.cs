using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task01
{
    internal class Program //todo pn ну, а как же вывести в консоль результат?
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
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var comparer = new StringComparer(CompareStrings);
            var strs = ConsoleUI.InputStrings();
            var sortedArray = Sort(strs, comparer);
            ConsoleUI.OutputStrings(sortedArray);

            Console.ReadKey();
        }
    }
}
