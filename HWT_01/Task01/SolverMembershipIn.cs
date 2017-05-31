namespace Task01
{
    using System;
    using System.Collections.Generic;

    public class SolverMembershipIn
    {
        private Dictionary<char, Func<Point, bool?>> plotFunctions;

        public SolverMembershipIn()
        {
            this.plotFunctions = new Dictionary<char, Func<Point, bool?>>();
            this.plotFunctions['а'] = this.SolveAPlot;
            this.plotFunctions['б'] = this.SolveBPlot;
            this.plotFunctions['в'] = this.SolveCPlot;
            this.plotFunctions['г'] = this.SolveDPlot;
            this.plotFunctions['д'] = this.SolveEPlot;
            this.plotFunctions['е'] = this.SolveFPlot;
            this.plotFunctions['ж'] = this.SolveGPlot;
            this.plotFunctions['з'] = this.SolveHPlot;
            this.plotFunctions['и'] = this.SolveIPlot;
            this.plotFunctions['к'] = this.SolveJPlot;
        }

        public bool? IsInPlot(Point inputPoint, char letPlot)
        {
            if (!this.plotFunctions.ContainsKey(letPlot))
            {
                return null;
            }

            return this.plotFunctions[letPlot](inputPoint);
        }

        private bool? SolveAPlot(Point inputPoint)
        {
            var centerCircle = new Point(0.0, 0.0);
            var radiusCircle = 1.0;

            return Plot.IsInCircle(centerCircle, radiusCircle, inputPoint);
        }

        private bool? SolveBPlot(Point inputPoint)
        {
            var centerCircle = new Point(0.0, 0.0);
            var largerRadius = 1.0;
            var smallerRadius = 0.5;

            var inLargerCircle = Plot.IsInCircle(centerCircle, largerRadius, inputPoint);
            var inSmallerCircle = Plot.IsInCircle(centerCircle, smallerRadius, inputPoint, false);
            if (!inLargerCircle.HasValue || !inSmallerCircle.HasValue)
            {
                return null;
            }

            return inLargerCircle.Value && !inSmallerCircle.Value;
        }

        private bool? SolveCPlot(Point inputPoint)
        {
            var rectangle = new[] { new Point(-1.0, 1.0), new Point(1.0, 1.0), new Point(1.0, -1.0), new Point(-1.0, -1.0) };

            return Plot.IsInRectangle(inputPoint, rectangle);
        }

        private bool? SolveDPlot(Point inputPoint)
        {
            var rectangle = new[] { new Point(-1.0, 0.0), new Point(0.0, 1.0), new Point(1.0, 0.0), new Point(0.0, -1.0) };

            return Plot.IsInRectangle(inputPoint, rectangle);
        }

        private bool? SolveEPlot(Point inputPoint)
        {
            var rectangle = new[] { new Point(-0.5, 0.0), new Point(0.0, 1.0), new Point(0.5, 0.0), new Point(0.0, -1.0) };

            return Plot.IsInRectangle(inputPoint, rectangle);
        }

        private bool? SolveFPlot(Point inputPoint)
        {
            var centerPoint = new Point(0.0, 0.0);
            var radiusSemicircle = 1.0;
            var triangle = new[] { new Point(0.0, -1.0), new Point(-2.0, 0.0), new Point(0.0, 1.0) };

            if (inputPoint.X >= centerPoint.X)
            {
                return Plot.IsInCircle(centerPoint, radiusSemicircle, inputPoint);
            }

            return Plot.IsInTriangle(inputPoint, triangle);
        }

        private bool? SolveGPlot(Point inputPoint)
        {
            var triangle = new[] { new Point(-1.5, -1.0), new Point(0.0, 2.0), new Point(1.5, -1.0) };

            return Plot.IsInTriangle(inputPoint, triangle);
        }

        private bool? SolveHPlot(Point inputPoint)
        {
            var polygon = new[]
            {
                new Point(-1.0, 0.0), new Point(-1.0, 1.0), new Point(0.0, 0.0), new Point(1.0, 1.0), new Point(1.0, 0.0),
                new Point(1.0, -2.0), new Point(-1.0, -2.0)
            };

            var inFirstTriangle = Plot.IsInTriangle(inputPoint, polygon[0], polygon[1], polygon[2]);
            var inSecondTriangle = Plot.IsInTriangle(inputPoint, polygon[2], polygon[3], polygon[4]);
            var inRectangle = Plot.IsInRectangle(inputPoint, polygon[4], polygon[5], polygon[6], polygon[0]);

            if (!inFirstTriangle.HasValue || !inSecondTriangle.HasValue || !inRectangle.HasValue)
            {
                return null;
            }

            return inFirstTriangle.Value || inSecondTriangle.Value || inRectangle.Value;
        }

        private bool? SolveIPlot(Point inputPoint)
        {
            var polygon = new[] { new Point(-2.0, -1.0), new Point(-1.0, 1.0), new Point(0.0, 0.0), new Point(1.0, 0.0) };
            var inFirstTriangle = Plot.IsInTriangle(inputPoint, polygon[0], polygon[1], polygon[2]);
            var inSecondTriangle = Plot.IsInTriangle(inputPoint, polygon[2], polygon[3], polygon[0]);

            if (!inFirstTriangle.HasValue || !inSecondTriangle.HasValue)
            {
                return null;
            }

            return inFirstTriangle.Value || inSecondTriangle.Value;
        }

        private bool? SolveJPlot(Point inputPoint)
        {
            var yThreshold = 1.0;
            var triangle = new[] { new Point(-1.0, 1.0), new Point(0.0, 0.0), new Point(1.0, 1.0) };
            var inTriangle = Plot.IsInTriangle(inputPoint, triangle);

            if (!inTriangle.HasValue)
            {
                return null;
            }

            return inputPoint.Y >= yThreshold || inTriangle.Value;
        }
    }
}
