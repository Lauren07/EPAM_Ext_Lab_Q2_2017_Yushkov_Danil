namespace Task04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Program
    {
        public static string[] GenerateStrings(int count, int lengthStr, bool isFirstPicture = false)
        {
            var resultStrs = new StringBuilder[count];
            for (int i = 0, countAsterisk = 1; i < count; i++, countAsterisk += 2)
            {
                if (isFirstPicture && i == 1)
                {
                    countAsterisk -= 2;
                }

                var spacesOneSide = (lengthStr - countAsterisk) / 2;
                resultStrs[i] = new StringBuilder();
                resultStrs[i].Append(' ', spacesOneSide);
                resultStrs[i].Append('*', countAsterisk);
            }

            return resultStrs.Select(str => str.ToString())
                .ToArray();
        }

        public static List<string[]> GenerateManyStrings(int countStrs)
        {
            var resultPictures = new List<string[]>();
            var lengthStr = (countStrs * 2) + 1;
            resultPictures.Add(GenerateStrings(3, lengthStr, true));
            for (int i = 0, curCount = 3; i < countStrs - 1; i++, curCount++)
            {
                resultPictures.Add(GenerateStrings(curCount, lengthStr));
            }

            return resultPictures;
        }

        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var countStrs = ConsoleUI.ReadCountStrings();
            var result = GenerateManyStrings(countStrs);
            foreach (var resultStrings in result)
            {
                ConsoleUI.WriteResultStrings(resultStrings);
            }

            Console.ReadKey();
        }
    }
}
