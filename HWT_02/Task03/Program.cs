namespace Task03
{
    using System;
    using System.Linq;
    using System.Text;

    internal class Program
    {
        public static string[] GenerateStrings(int count)
        {
            var resultStrs = new StringBuilder[count];
            var countChars = (count * 2) - 1;
            for (int i = 0, countAsterisk = 1; i < count; i++, countAsterisk += 2)
            {
                var spacesOneSide = (countChars - countAsterisk) / 2;
                resultStrs[i] = new StringBuilder();
                resultStrs[i].Append(' ', spacesOneSide);
                resultStrs[i].Append('*', countAsterisk);
            }

            return resultStrs.Select(str => str.ToString())
                             .ToArray();
        }

        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var countStrs = ConsoleUI.ReadCountStrings();
            var result = GenerateStrings(countStrs);
            ConsoleUI.WriteResultStrings(result);
            Console.ReadKey();
        }
    }
}
