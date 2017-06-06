using System;
using System.Collections.Generic;
using System.Text;
using Task01;

namespace Task02
{
    internal class Program
    {
        private static string DoubleString(string doubledStr, string secondStr)
        {
            var resultString = new StringBuilder();
            var dictionaryChars = GetDictionaryChars(secondStr);
            foreach (var letter in doubledStr)
            {
                resultString.Append(letter);
                if (dictionaryChars.ContainsKey(letter))
                {
                    resultString.Append(letter);
                }
            }

            return resultString.ToString();
        }

        private static Dictionary<char, bool> GetDictionaryChars(string str)
        {
            var charsDict = new Dictionary<char, bool>();
            for (var i = 0; i < str.Length; i++)
            {
                charsDict[str[i]] = true;
            }

            return charsDict;
        }

        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            while (true)
            {
                var strs = ConsoleUI.ReadStrings();
                var resultStr = DoubleString(strs.Item1, strs.Item2);
                ConsoleUI.WriteResultStr(resultStr);
            }
        }
    }
}
