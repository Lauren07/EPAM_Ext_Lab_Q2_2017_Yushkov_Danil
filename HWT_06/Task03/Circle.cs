using System;

namespace Task03
{
    public class Circle : Round
    {
        public double Area
        {
            get
            {
                return Math.PI * Math.Pow(this.Radius, 2);
            }
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Площадь круга: {this.Area}");
        }
    }
}
