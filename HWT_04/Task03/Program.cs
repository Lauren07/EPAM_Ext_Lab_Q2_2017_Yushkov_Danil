using System;
using System.Diagnostics;
using System.Text;

namespace Task03
{
    internal class Program
    {
        // РЕЗУЛЬТАТЫ ТЕСТОВ: http://imgur.com/a/259Jy
        private static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var timer = new Stopwatch();
            string str = string.Empty;
            StringBuilder sb = new StringBuilder();
            int N = 100000;
            timer.Start();
            for (int i = 0; i < N; i++)
            {
                str += "*";
            }

            timer.Stop();
            Console.WriteLine($"Время работы String (N={N}): {timer.ElapsedTicks} ticks");
            timer.Reset();
            timer.Start();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");
            }

            timer.Stop();
            Console.WriteLine($"\nВремя работы StringBuilder (N={N}): {timer.ElapsedTicks} ticks");
            Console.ReadKey();
        }
    }
}
