namespace Task02
{
    using System;
    using System.Text;

    internal class Program
    {
        public static string[] GenerateStrings(int count)
        {
            var resultStrs = new string[count];
            resultStrs[0] = "*";
            for (var i = 1; i < count; i++)
            {
                resultStrs[i] = resultStrs[i - 1] + "*";
            }

            return resultStrs;
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
