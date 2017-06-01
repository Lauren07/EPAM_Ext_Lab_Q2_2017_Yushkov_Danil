using System.Text;

namespace Task02
{
    using System;

    internal class Program
    {
        public static double CalculateKoeffA(double h)
        {
            var numerator = Math.Abs(Math.Sin(8 * h)) + 17;
            var denominator = Math.Pow(1 - (Math.Sin(4 * h) * Math.Cos(Math.Pow(h, 2) + 18)), 2);
            return Math.Sqrt(numerator / denominator);
        }

        public static double CalculateKoeffB(double a, double h)
        {
            var denominator = 3 + Math.Abs(Math.Tan(a * Math.Pow(h, 2)) - Math.Sin(a * h));
            return 1 - Math.Sqrt(3 / denominator);
        }

        public static double CalculateKoeffC(double a, double b, double h)
        {
            return (a * Math.Pow(h, 2) * Math.Sin(b * h)) + (b * Math.Pow(h, 3) * Math.Cos(a * h));
        }

        public static double ReadInputH()
        {
            var h = 0.0;
            var isEntered = false;
            while (!isEntered)
            {
                isEntered = true;
                Console.WriteLine("Введите действительное число h");
                var strH = Console.ReadLine();
                if (!double.TryParse(strH, out h))
                {
                    Console.WriteLine("Ошибка ввода числа! Пожалуйста, проверьте правильность ввода действительного числа");
                    isEntered = false;
                }
            }

            return h;
        }

        private static void WriteResult(double a, double b, double c, QuadraticEquation equation)
        {
            var roots = equation.GetRoots();
            Console.WriteLine($"a={a}, b={b}, c={c}\nDiscriminant={equation.Discriminant}");
            if (roots.Count == 0)
            {
                Console.WriteLine("Действительных корней нет.");
            }

            for (var i = 0; i < roots.Count; i++)
            {
                Console.Write($"X{i + 1}={roots[i]}  ");
            }
        }

        private static void Main(string[] args)
        {
	        Console.InputEncoding = Encoding.Unicode;
	        Console.OutputEncoding = Encoding.Unicode;

			double a = 0, b = 0, c = 0, h;
            bool isErrors;
            do
            {
                h = ReadInputH();
                isErrors = false;
                try
                {
                    a = CalculateKoeffA(h);
                    b = CalculateKoeffB(a, h);
                    c = CalculateKoeffC(a, b, h);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Деление на 0 в одном из параметров!");
                    isErrors = true;
                }
            }
            while (isErrors);

            var equation = new QuadraticEquation();
            equation.SolveEquation(a, b, c);
            WriteResult(a, b, c, equation);
            Console.ReadKey();
        }
    }
}
