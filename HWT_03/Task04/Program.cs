using System;
using System.Text;
using Task03;

namespace Task04
{
    internal class Program
    {
        private static int[,] GenerateIntArray(int count, int maxInt)
        {
            var random = new Random();
            var resultMas = new int[count, count];
            for (var i = 0; i < count; i++)
            {
                for (var j = 0; j < count; j++)
                {
                    resultMas[i, j] = random.Next(maxInt);
                }
            }

            return resultMas;
        }

        private static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        private static int SumInArray(int[,] array)
        {
            var resultSum = 0;
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    if (IsEven(i + j))
                    {
                        resultSum += array[i, j];
                    }
                }
            }

            return resultSum;
        }

        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var countElements = 5;
            var array = GenerateIntArray(countElements, 10);
            var sum = SumInArray(array);

            ConsoleUI.WriteArray(array);
            ConsoleUI.WriteSum(sum);
            Console.ReadKey();
        }
    }
}
