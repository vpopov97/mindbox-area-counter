using AreaCounter.Core.Domain.Common;

namespace AreaCounter.Core.Domain.Entities;

public class TriangleEntity : IFigure
{
    private readonly double _sideA, _sideB, _sideC;
    public TriangleEntity(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            throw new ArgumentException("Стороны треугольника должны быть положительными.");
        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
    }

    public double GetArea()
    {
        if (IsRightTriangle())
            return AreaOfRightTriangle();

        var semiPerimeter = (_sideA + _sideB + _sideC) / 2.0;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - _sideA) * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));
    }

    public bool IsRightTriangle()
    {
        double[] sides = new double[] { _sideA, _sideB, _sideC };
        Array.Sort(sides);
        return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 0.000001;
    }

    private double AreaOfRightTriangle()
    {
        double[] sides = new double[] { _sideA, _sideB, _sideC };
        Array.Sort(sides);
        return 0.5 * sides[0] * sides[1];
    }
}