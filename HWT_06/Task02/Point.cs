namespace Task02
{
    public class Point
    {
        public static Point DefaultPoint
        {
            get
            {
                return new Point(0, 0);
            }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
