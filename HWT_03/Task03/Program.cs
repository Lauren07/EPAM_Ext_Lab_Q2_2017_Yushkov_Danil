using System;
using System.Linq;
using System.Text;

namespace Task03
{
    internal class Program
    {
        private static int[] GenerateIntArray(int count, int minInt, int maxInt)
        {
            var random = new Random();
            var resultMas = new int[count];
            for (var i = 0; i < count; i++)
            {
                resultMas[i] = random.Next(minInt, maxInt);
            }

            return resultMas;
        }

        private static int SumInArray(int[] array)
        {
            return array.Where(x => x >= 0).Sum();
        }

        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var array = GenerateIntArray(10, -10, 10);
            var sum = SumInArray(array);
            ConsoleUI.WriteArray(array);
            ConsoleUI.WriteSum(sum);

            Console.ReadKey();
        }
    }
}
