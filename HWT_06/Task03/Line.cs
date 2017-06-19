using System;

namespace Task03
{
    public class Line : Figure
    {
        private Tuple<Point, Point> points;

        public double LengthLine
        {
            get
            {
                return Math.Sqrt(Math.Pow(this.Points.Item2.X - this.Points.Item1.X, 2) +
                                 Math.Pow(this.Points.Item2.Y - this.Points.Item1.Y, 2));
            }
        }

        public Tuple<Point, Point> Points
        {
            get
            {
                return this.points;
            }

            set
            {
                if (value == null || value.Item1 == null || value.Item2 == null)
                {
                    throw new Exception("Incorrect format line.");
                }

                this.points = value;
            }
        }

        public Line()
        {
            this.Create();
        }

        public override void Display()
        {
            Console.WriteLine(ConsoleResource.FirstPointMessage + this.Points.Item1);
            Console.WriteLine(ConsoleResource.FirstPointMessage + this.Points.Item2);
            Console.WriteLine($"{ConsoleResource.LengthLineMessage} {this.LengthLine:0.000}");
        }

        public override void Create()
        {
            var points = new Point[2];
            for (var i = 0; i < 2; i++)
            {
                Console.WriteLine($"Введите координаты X и Y {i + 1} точки (через пробел):");
                points[i] = Point.ReadPoint();
            }

            this.Points = Tuple.Create(points[0], points[1]);
        }
    }
}
