﻿using System;

namespace Task03
{
    public class Round : Figure
    {
        private Point center;
        private int radius;

        public Point Center
        {
            get
            {
                return this.center;
            }

            set
            {
                if (value == null)
                {
                    throw new Exception("Incorrect format point.");
                }

                this.center = value;
            }
        }

        public int Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new Exception("Incorrect radius.");
                }

                this.radius = value;
            }
        }

        public double LengthBorder
        {
            get { return 2 * Math.PI * this.Radius; }
        }

        public Round()
        {
            this.Create();
        }

        public override void Display()
        {
            Console.WriteLine(ConsoleResource.CenterRoundMessage + this.Center);
            Console.WriteLine(ConsoleResource.RadiusRoundMessage + this.Radius);
            Console.WriteLine(ConsoleResource.LengthBorderMessage + $"{this.LengthBorder:0.000}");
        }

        public override void Create()
        {
            Console.WriteLine(ConsoleResource.InputCenterRound);
            this.Center = Point.ReadPoint();
            for (; ;)
            {
                Console.WriteLine(ConsoleResource.InputRadius);
                var radiusStr = Console.ReadLine();
                if (int.TryParse(radiusStr, out this.radius))
                {
                    break;
                }

                Console.WriteLine(ConsoleResource.ErrorInputFormat);
            }

            this.Radius = this.radius;
        }
    }
}
