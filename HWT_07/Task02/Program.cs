using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task02
{
    public class Program
    {
        private static Dictionary<string, int> GetFrequency(string text)
        {
            var separators = new[] { ' ', ',' };
            var dictWords = text.Split(separators)
                .Where(word => word.Length > 0)
                .GroupBy(word => word.ToLower())
                .ToDictionary(group => group.Key, group => group.Count());
            return dictWords;
        }

        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var text = ConsoleUI.InputText();
            var dictFrequency = GetFrequency(text);
            ConsoleUI.OutputDict(dictFrequency);
        }
    }
}
