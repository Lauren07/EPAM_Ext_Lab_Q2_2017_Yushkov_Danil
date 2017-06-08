using System;
using NUnit.Framework;

namespace Task01
{
    public class RoundTest
    {
        [Test]
        public void SimpleInitializationTest()
        {
            var point = new Point(-1, 1);
            var radius = 10;
            var round = new Round(point, radius);
            Assert.IsNotNull(round.Center);
            Assert.AreEqual(point.X, round.Center.X);
            Assert.AreEqual(point.Y, round.Center.Y);
            Assert.AreEqual(radius, round.Radius);
        }

        [Test]
        public void IncorrectRadiusTest()
        {
            var radius = -10;
            var round = new Round(new Point(1, 1), radius);
            Assert.IsTrue(round.Radius >= 0);
        }

        [Test]
        public void CalculateAreaTest()
        {
            var point = new Point(2, -1);
            var radius = 10;
            var round = new Round(point, radius);
            var expectedArea = Math.PI * Math.Pow(radius, 2);
            Assert.AreEqual(expectedArea, round.Area);
        }

        [Test]
        public void CalculateLengthTest()
        {
            var point = new Point(4, -2);
            var radius = 5;
            var round = new Round(point, radius);
            var expectedLength = 2 * Math.PI * radius;
            Assert.AreEqual(expectedLength, round.LengthCircumscribedCircle);
        }

        [Test]
        public void IncorrectRadiusAreaTest()
        {
            var point = new Point(4, -5);
            var radius = -5;
            var round = new Round(point, radius);
            Assert.AreEqual(0, round.LengthCircumscribedCircle);
            Assert.AreEqual(0, round.Radius);
        }

        [Test]
        public void NullPointTest()
        {
            var radius = 10;
            var round = new Round(null, radius);
            Assert.AreEqual(0, round.Center.X);
            Assert.AreEqual(0, round.Center.Y);
        }
    }
}
