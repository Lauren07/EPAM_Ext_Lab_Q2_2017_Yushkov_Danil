using System;

namespace Task02
{
    public class Ring : Round
    {
        private int innerRadius;

        public int InnerRadius
        {
            get
            {
                return this.innerRadius;
            }

            set
            {
                if (value < 0 || value > this.Radius)
                {
                    throw new Exception("Incorrect inner radius.");
                }

                this.innerRadius = value;
            }
        }

        public double LengthInnerBorder
        {
            get { return 2 * Math.PI * this.InnerRadius; }
        }

        public double SumLengthBorders
        {
            get { return this.LengthInnerBorder + this.LengthBorder; }
        }

        public Ring(Point center, int outerRadius, int innerRadius)
            : base(center, outerRadius)
        {
            this.InnerRadius = innerRadius;
        }
    }
}
