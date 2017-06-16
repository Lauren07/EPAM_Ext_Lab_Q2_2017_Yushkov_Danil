using System;

namespace Task03
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
                if (value < 0)
                {
                    throw new Exception("Incorrect radius.");
                }

                this.innerRadius = value;
            }
        }

        public double LengthInnerBorder
        {
            get { return 2 * Math.PI * this.InnerRadius; }
        }

        public override void Create()
        {
            base.Create();
            Console.WriteLine("Введите внутренний радиус");
            int r;
            for (; ;)
            {
                var rStr = Console.ReadLine();
                if (int.TryParse(rStr, out r) && r < this.Radius)
                {
                    break;
                }

                Console.WriteLine(ConsoleResource.ErrorInputFormat);
            }

            this.InnerRadius = r;
        }

        public override void Display()
        {
            Console.WriteLine($"Центр кольца: {this.Center}");
            Console.WriteLine($"Внешний радиус: {this.Radius}, Внутренний радиус: {this.InnerRadius}");
            Console.WriteLine($"Длина внешней границы: {this.LengthBorder:0.000}, Длина внутренней границы: {this.LengthInnerBorder:0.000}");
        }
    }
}
