using System;

namespace Task01
{
    public static class ConsoleUI
    {
        public static void WriteArray(int[] array, string nameArr)
        {
            Console.WriteLine($"{nameArr}:");
            foreach (var element in array)
            {
                Console.WriteLine(element);
            }
        }

        public static void WriteMinMax(int min, int max)
        {
            Console.WriteLine($"Минимальный элемент массива: {min}");
            Console.WriteLine($"Максимальный элемент массива: {max}");
        }
    }
}
