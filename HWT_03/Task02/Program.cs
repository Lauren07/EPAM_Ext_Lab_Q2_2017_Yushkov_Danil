using System;
using System.Text;

namespace Task02
{
    internal class Program
    {
        private static int[][][] GenerateIntArray(int count1, int count2, int count3, int minInt, int maxInt)
        {
            var random = new Random();
            var array = new int[count1][][];
            for (var i = 0; i < count1; i++)
            {
                array[i] = new int[count2][];
                for (var j = 0; j < count2; j++)
                {
                    array[i][j] = new int[count3];
                    for (var t = 0; t < count3; t++)
                    {
                        array[i][j][t] = random.Next(minInt, maxInt);
                    }
                }
            }

            return array;
        }

        private static void SwitchToZeros(int[][][] array)
        {
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array[i].Length; j++)
                {
                    for (var t = 0; t < array[i][j].Length; t++)
                    {
                        array[i][j][t] = Math.Min(0, array[i][j][t]);
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            int count1 = 3, count2 = 5, count3 = 5;
            var array = GenerateIntArray(count1, count2, count3, -15, 15);
            ConsoleUI.WriteArray(array, "Исходный массив");

            SwitchToZeros(array);
            ConsoleUI.WriteArray(array, "Измененный масив");
            Console.ReadKey();
        }
    }
}
