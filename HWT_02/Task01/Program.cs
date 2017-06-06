// Написать программу, которая определяет площадь прямоугольника со сторонами a и b.
// Если пользователь вводит некорректные значения (отрицательные, или 0), должно выдаваться сообщение об ошибке.Возможность ввода пользователем строки вида «абвгд», или нецелых чисел игнорировать.

namespace Task01
{
    using System;
    using System.Text;

    internal class Program
    {
        public static int? CalculateAreaRect(int a, int b)
        {
            if (a <= 0 || b <= 0)
            {
                return null;
            }

            return a * b;
        }

        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            while (true)
            {
                var sidesAB = ConsoleUI.ReadRectSides();
                var result = CalculateAreaRect(sidesAB.Item1, sidesAB.Item2);
                ConsoleUI.WriteResult(result);
            }
        }
    }
}
