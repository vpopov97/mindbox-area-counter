using AreaCounter.Core.Domain.Common;

namespace AreaCounter.Core.Domain.Entities;

public class TriangleEntity : IFigure 
{
    private readonly double _sideA, _sideB, _sideC;
    public TriangleEntity(double sideA, double sideB, double sideC)
    {
       _sideA = sideA;
       _sideB = sideB;
       _sideC = sideC;
    }

    public double GetArea() {
        if (_sideA <= 0 || _sideB <= 0 || _sideC <= 0)
        {
            throw new ArgumentException("Стороны треугольника должны быть положительными.");
        }

        var semiPerimeter = (_sideA + _sideB + _sideC) / 2.0;

        return Math.Sqrt(semiPerimeter * (semiPerimeter - _sideA) * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));
    }
}