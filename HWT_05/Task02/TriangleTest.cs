using NUnit.Framework;

namespace Task02
{
    public class TriangleTest
    {
        [Test]
        public void InitTriangleTest()
        {
            int a = 5, b = 4, c = 3;
            var triangle = new Triangle(a, b, c);
            Assert.AreEqual(a, triangle[0]);
            Assert.AreEqual(b, triangle[1]);
            Assert.AreEqual(c, triangle[2]);
            triangle[0] = c;
            Assert.AreEqual(c, triangle[0]);
        }

        [Test]
        public void AreaTriangleTest()
        {
            var trinagle = new Triangle(2, 5, 4);
            var expectedArea = 3.79967;
            Assert.AreEqual(expectedArea, trinagle.Area, 0.001);
        }

        [Test]
        public void PerimeterTriangleTest()
        {
            var trinagle = new Triangle(1, 3, 4);
            var expectedPerimeter = 4;
            Assert.AreEqual(expectedPerimeter, trinagle.Perimeter);
        }

        [Test]
        public void IncorrectTrinagleTest()
        {
            var triangle = new Triangle(-2, -3, 0);
            for (var i = 0; i < 3; i++)
            {
                Assert.IsTrue(triangle[i] >= 0);
            }

            Assert.AreEqual(0.0, triangle.Perimeter);
            Assert.AreEqual(0.0, triangle.Area);
        }
    }
}
