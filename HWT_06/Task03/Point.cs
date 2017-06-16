using System;

namespace Task03
{
    public class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static bool operator ==(Point p1, Point p2)
        {
            if ((object)p1 == null || (object)p2 == null)
            {
                return (object)p1 == null && (object)p2 == null;
            }

            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }

        public override string ToString()
        {
            return $"X={this.X}  Y={this.Y}";
        }

        public static Point ReadPoint()
        {
            int x = 0, y = 0;
            for (; ;)
            {
                var point = Console.ReadLine().Split(' ');
                if (point.Length == 2 && int.TryParse(point[0], out x) && int.TryParse(point[1], out y))
                {
                    return new Point(x, y);
                }

                Console.WriteLine(ConsoleResource.ErrorInputFormat);
            }
        }
    }
}
