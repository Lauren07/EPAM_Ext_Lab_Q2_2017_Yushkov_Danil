namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QuadraticEquation
    {
        public double Discriminant { get; private set; }

        private List<double> roots;

        public List<double> GetRoots()
        {
            return (this.roots ?? new List<double>()).Distinct().ToList();
        }

        public void SolveEquation(double a, double b, double c)
        {
            this.roots = new List<double>();

            if (a == 0.0)
            {
                this.Discriminant = Math.Pow(b, 2);
                this.roots.Add(-c / b);
                return;
            }

            this.Discriminant = Math.Pow(b, 2) - (4 * a * c);
            if (this.Discriminant < 0)
            {
                return;
            }

            this.roots.Add((-b + Math.Sqrt(this.Discriminant)) / (2 * a));
            this.roots.Add((-b - Math.Sqrt(this.Discriminant)) / (2 * a));
        }
    }
}
