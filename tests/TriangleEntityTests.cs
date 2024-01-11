using AreaCounter.Core.Domain.Entities;

namespace AreaCounter.Tests
{
    public class TriangleEntityTests
    {
        [Theory]
        [InlineData(3, 4, 5, 6)] // прямоугольный треугольник
        [InlineData(3, 4, 6, 5.332682251925386)] // непрямоугольный треугольник
        public void TestArea(double sideA, double sideB, double sideC, double expectedArea)
        {
            var triangle = new TriangleEntity(sideA, sideB, sideC);
            Assert.Equal(expectedArea, triangle.GetArea(), 1);
        }

        [Theory]
        [InlineData(-1, 4, 5)] 
        [InlineData(1, -4, 5)]
        [InlineData(1, 4, -5)] 
        public void TestNegativeSides(double sideA, double sideB, double sideC)
        {
            Assert.Throws<ArgumentException>(() => new TriangleEntity(sideA, sideB, sideC));
        }

        [Fact]
        public void TestIsRightTriangle()
        {
            var triangle = new TriangleEntity(3, 4, 5);
            Assert.True(triangle.IsRightTriangle());
        }

        [Fact]
        public void TestIsNotRightTriangle()
        {
            var triangle = new TriangleEntity(3, 4, 6);
            Assert.False(triangle.IsRightTriangle());
        }
    }
}

