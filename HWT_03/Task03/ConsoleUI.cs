using System;

namespace Task03
{
    public static class ConsoleUI
    {
        public static void WriteArray(int[] array)
        {
            Console.WriteLine("Сгенерированный массив:");
            foreach (var element in array)
            {
                Console.WriteLine(element);
            }
        }

        public static void WriteSum(int value)
        {
            Console.WriteLine($"Сумма неотрицательных элементов: {value}");
        }
    }
}
