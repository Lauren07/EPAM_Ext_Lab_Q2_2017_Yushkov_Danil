using System;

namespace Task03
{
    public class Rectangle : Figure
    {
        private Tuple<Point, Point> points;

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
                    throw new Exception("Incorrect points.");
                }

                if (value.Item1.X == value.Item2.X || value.Item1.Y == value.Item2.Y)
                {
                    throw new Exception("Incorrect rectangle.");
                }

                this.points = value;
            }
        }

        public int Height
        {
            get
            {
                return Math.Abs(this.Points.Item1.Y - this.Points.Item2.Y);
            }
        }

        public int Width
        {
            get
            {
                return Math.Abs(this.Points.Item1.X - this.Points.Item2.X);
            }
        }

        public int Area
        {
            get
            {
                return this.Width * this.Height;
            }
        }

        public int Perimeter
        {
            get
            {
                return 2 * (this.Width + this.Height);
            }
        }

        public Rectangle()
        {
            this.Create();
        }

        public override void Display()
        {
            Console.WriteLine(ConsoleResource.HeightRectMessage + this.Height);
            Console.WriteLine(ConsoleResource.WidthRectMessage + this.Width);
            Console.WriteLine(ConsoleResource.AreaRectMessage + this.Area);
            Console.WriteLine(ConsoleResource.PerimeterRectMessage + this.Perimeter);
        }

        public override void Create()
        {
            Console.WriteLine(ConsoleResource.InputFirstPointRect);
            var p1 = Point.ReadPoint();
            Console.WriteLine(ConsoleResource.InputSecondPointRect);
            var p2 = Point.ReadPoint();
            this.Points = Tuple.Create(p1, p2);
        }
    }
}
