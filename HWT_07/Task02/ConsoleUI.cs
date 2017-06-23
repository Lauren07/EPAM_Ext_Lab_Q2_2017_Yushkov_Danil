using System;
using System.Collections.Generic;

namespace Task02
{
    public static class ConsoleUI
    {
        public static string InputText()
        {
            for (; ;)
            {
                Console.WriteLine(MessageRecource.InputMessage);
                var text = Console.ReadLine();
                if (text.Length > 0)
                {
                    return text;
                }

                Console.WriteLine(MessageRecource.ErrorInputMessage);
            }
        }

        public static void OutputDict(Dictionary<string, int> dictFrequency)
        {
            Console.WriteLine(MessageRecource.OutputMessage);
            foreach (var wordFrequency in dictFrequency)
            {
                Console.WriteLine($"{wordFrequency.Key} - {wordFrequency.Value}");
            }
        }
    }
}
