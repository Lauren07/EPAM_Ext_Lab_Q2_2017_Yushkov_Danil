namespace Task01
{
    using System;
    using System.Linq;

    public class Plot
    {
        public static bool? IsInCircle(Point centerCircle, double radiusCircle, Point inputPoint, bool togetherBorder = true)
        {
            if (centerCircle == null || inputPoint == null)
            {
                return null;
            }

            var distanceToPoint =
                Math.Sqrt(Math.Pow(inputPoint.X - centerCircle.X, 2) + Math.Pow(inputPoint.Y - centerCircle.Y, 2));
            if (togetherBorder)
            {
                return distanceToPoint <= radiusCircle;
            }
            else
            {
                return distanceToPoint < radiusCircle;
            }
        }

        public static bool? IsInTriangle(Point inputPoint, params Point[] triangle)
        {
            if (inputPoint == null || triangle.Length != 3)
            {
                return null;
            }

            var mas = new double[3];
            for (var i = 0; i < 3; i++)
            {
                mas[i] = ((triangle[i].X - inputPoint.X) * (triangle[(i + 1) % 3].Y - triangle[i].Y)) -
                         ((triangle[(i + 1) % 3].X - triangle[i].X) * (triangle[i].Y - inputPoint.Y));
            }

            return mas.All(x => x >= 0) || mas.All(x => x <= 0);
        }

        public static bool? IsInRectangle(Point inputPoint, params Point[] rectangle)
        {
            if (inputPoint == null || rectangle.Length != 4)
            {
                return null;
            }

            var isInFirstTriangle = IsInTriangle(inputPoint, rectangle[0], rectangle[1], rectangle[2]);
            var isInSecondTriangle = IsInTriangle(inputPoint, rectangle[2], rectangle[3], rectangle[0]);

            if (!isInFirstTriangle.HasValue || !isInSecondTriangle.HasValue)
            {
                return null;
            }

            return isInFirstTriangle.Value || isInSecondTriangle.Value;
        }
    }
}
