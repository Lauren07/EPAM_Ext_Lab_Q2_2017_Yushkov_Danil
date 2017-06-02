// Если выписать все натуральные числа меньше 10, кратные 3, или 5, то получим 3, 5, 6 и 9. Сумма этих чисел будет равна 23. 
// Напишите программу, которая выводит на экран сумму всех чисел меньше 1000, кратных 3, или 5.
namespace Task05
{
    using System;
    using System.Text;

    internal class Program
    {
        public static bool IsDivisible(int n, params int[] divisors)
        {
            for (var i = 0; i < divisors.Length; i++)
            {
                if (n % divisors[i] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static int CalculateSum(int maxN, params int[] divisors)
        {
            var sumResult = 0;
            for (var i = 1; i < maxN; i++)
            {
                if (IsDivisible(i, divisors))
                {
                    sumResult += i;
                }
            }

            return sumResult;
        }

        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var result = CalculateSum(1000, 3, 5);
            Console.WriteLine($"Сумма чисел всех чисел меньше 1000 и кратных 3 или 5: {result}");
            Console.ReadKey();
        }
    }
}
