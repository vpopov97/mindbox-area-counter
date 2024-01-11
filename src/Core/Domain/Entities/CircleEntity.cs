using AreaCounter.Core.Domain.Common;

namespace AreaCounter.Core.Domain.Entities;

public class CircleEntity : IFigure 
{
    private readonly double _radius;
    public CircleEntity(double radius)
    {
        _radius = radius;
    }

    public double GetArea() {
        if (_radius < 0)
        {
            throw new ArgumentException("Радиус должен быть положительным");
        }

        return Math.PI * Math.Pow(_radius, 2);
    }
}