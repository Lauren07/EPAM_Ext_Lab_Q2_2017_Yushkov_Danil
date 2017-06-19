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
            Console.WriteLine(ConsoleResource.InputInnerRadius);
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
            Console.WriteLine(ConsoleResource.CenterRingMessage + this.Center);
            Console.WriteLine(ConsoleResource.OuterRadius + this.Radius);
            Console.WriteLine(ConsoleResource.InnerRadius + this.InnerRadius);
            Console.WriteLine($"{ConsoleResource.LengthOuterBorderMessage} {this.LengthBorder:0.000}, {ConsoleResource.LengthOuterBorderMessage} {this.LengthInnerBorder:0.000}");
        }
    }
}
