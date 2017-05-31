// ЗАДАНИЕ
// Написать консольное приложение, которое проверяет принадлежность точки заштрихованной области.
// Пользователь вводит координаты точки (x; y) и выбирает букву графика(a-к). В консоли должно высветиться сообщение: «Точка[(x; y)] принадлежит фигуре[г]».

namespace Task01
{
    using System;
    using System.Linq;

    internal class Program
    {
        private static Point ReadInputPoint()
        {
            Console.WriteLine("Введите координаты точки (x,y). Например: \"2,0 3,0\"");

            var strPoint = Console.ReadLine();
            string[] points = (strPoint ?? string.Empty).Split(' ');
            double x;
            double y;
            if (points.Length < 2 || !double.TryParse(points[0], out x) || !double.TryParse(points[1], out y))
            {
                Console.WriteLine("Ошибка формата ввода данных!");
                return null;
            }

            return new Point(x, y);
        }

        private static char ReadLetterPlot()
        {
            Console.WriteLine("Введите букву графика (а-к)");
            var strChar = Console.ReadLine();
            return strChar.FirstOrDefault();
        }

        private static void Main(string[] args)
        {
            var solver = new SolverMembershipIn();
            bool? isInPlot = null;
            while (!isInPlot.HasValue)
            {
                var inputPoint = ReadInputPoint();
                if (inputPoint == null)
                {
                    continue;
                }

                var lettPlot = ReadLetterPlot();

                isInPlot = solver.IsInPlot(inputPoint, lettPlot);
                if (!isInPlot.HasValue)
                {
                    Console.WriteLine("Ошибка вычислений или запрашиваемый график не найден!");
                }
                else
                {
                    var particleDenail = !isInPlot.Value ? "не " : string.Empty;
                    Console.WriteLine(
                        $"Точка ({inputPoint.X};{inputPoint.Y}) {particleDenail}принадлежит фигуре '{lettPlot}'");
                }

                Console.ReadKey();
            }
        }
    }
}
