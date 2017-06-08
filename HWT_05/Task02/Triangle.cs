using System;
using System.Linq;

namespace Task02
{
    public class Triangle
    {
        private int[] sides;

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= this.sides.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.sides[index];
            }

            set
            {
                if (index < 0 || index >= this.sides.Length)
                {
                    throw new IndexOutOfRangeException();
                }

                this.sides[index] = Math.Max(0, value);
            }
        }

        public double Perimeter
        {
            get { return this.sides.Sum() / 2.0; }
        }

        public double Area
        {
            get
            {
                var p = this.Perimeter;
                return Math.Sqrt(p * (p - this.sides[0]) * (p - this.sides[1]) * (p - this.sides[2]));
            }
        }

        public Triangle(int a, int b, int c)
        {
            this.sides = new int[3];
            this[0] = a;
            this[1] = b;
            this[2] = c;
        }
    }
}
