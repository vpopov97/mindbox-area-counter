using AreaCounter.Core.Domain.Entities;

namespace AreaCounter.Tests
{
    public class CircleEntityTests
    {
        [Theory]
        [InlineData(3, Math.PI * 9)]
        [InlineData(0, 0)]
        [InlineData(1.5, Math.PI * 2.25)]
        public void TestAreaOfCircle(double radius, double expectedArea)
        {
            var circle = new CircleEntity(radius);
            Assert.Equal(expectedArea, circle.GetArea(), 1);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-0.1)]
        public void TestNegativeRadius(double radius)
        {
            Assert.Throws<ArgumentException>(() => new CircleEntity(radius));
        }
    }
}
