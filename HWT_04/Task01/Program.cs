﻿using System;
using System.Linq;
using System.Text;

namespace Task01
{
    internal class Program
    {
        private static double CalculateAverageLength(string[] words)
        {
            if (words.Length == 0)
            {
                return 0;
            }

            return words.Average(x => x.Length);
        }

        private static string[] SplitString(string str)
        {
            var separators = " ,:;.-!?";
            return str.Trim().Split(separators.ToCharArray()).Where(word => word.Length > 0).ToArray();
        }

        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            while (true)
            {
                var inputString = ConsoleUI.ReadString();
                var words = SplitString(inputString);
                var averageLength = CalculateAverageLength(words);
                ConsoleUI.WriteAverage(averageLength);
            }
        }
    }
}