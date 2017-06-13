using System;

namespace Task01
{
    public class Round
    {
        private int radius;
        private Point center;

        public Point Center
        {
            get { return this.center ?? new Point(0, 0); }//todo pn если тело геттера или сеттера не пустое, то лучше фигурные скобки на отдельных строках размещать. Значения по умолчанию - в константы.
            set { this.center = value; }
        }

        public int Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value > 0)
                {
                    this.radius = value;
                }
            }
        }

        public double Area
        {
            get { return Math.PI * Math.Pow(this.Radius, 2); }
        }

        public double LengthCircumscribedCircle
        {
            get { return 2 * Math.PI * this.Radius; }
        }

        public Round(Point center, int radius)
        {
            this.Center = center;
            this.Radius = radius;
        }
    }
}
