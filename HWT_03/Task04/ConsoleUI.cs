using System;

namespace Task03
{
    public static class ConsoleUI
    {
        public static void WriteArray(int[,] array)
        {
            Console.WriteLine("Сгенерированный массив:");
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0,-2}", array[i, j]);
                }

                Console.WriteLine();
            }
        }

        public static void WriteSum(int value)
        {
            Console.WriteLine($"Сумма элементов на четных позициях: {value}");
        }
    }
}
