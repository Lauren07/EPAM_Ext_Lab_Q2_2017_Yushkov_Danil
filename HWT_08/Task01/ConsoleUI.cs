using System;
using System.Linq;

namespace Task01
{
    public static class ConsoleUI
    {
        public static string[] InputStrings()
        {
            for (; ;)
            {
                Console.WriteLine(MessageResource.InputMessage);
                var words = (Console.ReadLine() ?? string.Empty).Split(' ')
                    .Where(str => str.Length > 0)
                    .ToArray();
                if (words.Length > 0)
                {
                    return words;
                }

                Console.WriteLine(MessageResource.ErrorInputMessage);
            }
        }

        public static void OutputStrings(string[] sortedStrings)
        {
            Console.WriteLine(MessageResource.OutputMessage);
            foreach (var str in sortedStrings)
            {
                Console.WriteLine(str);
            }
        }
    }
}
