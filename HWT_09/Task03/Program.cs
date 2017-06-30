using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Task03
{
    class Program
    {
        private static int[] GenerateArray(int n)
        {
            var array = new int[n];
            for (var i = 0; i < n; i++)
            {
                array[i] = i - (n / 2);
            }

            return array;
        }

        // Результаты тестов: http://imgur.com/a/TjgF8
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var methodNames = new[]
            {
                "Метод, реализующий поиск напрямую.", "Метод, использующий делегат.",
                "Метод, принимающий в кач-ве параметра анонимный метод.", "Метод, использующий лямбда-выражение.",
                "Метод, использующий LINQ-выражения."
            };

            var lengthArray = 1000000;
            var array = GenerateArray(lengthArray);
            var tester = new FinderTester(array);
            var timer = new Stopwatch();

            Console.WriteLine($"Длина массива: {lengthArray}");
            for (var i = 0; i < tester.Methods.Length; i++)
            {
                timer.Start();
                tester.Methods[i]().FirstOrDefault();
                timer.Stop();
                Console.WriteLine($"{methodNames[i]} Время: {timer.ElapsedTicks}");
                timer.Reset();
            }

            Console.ReadKey();
        }
    }
}
