using AreaCounter.Core.Domain.Common;

namespace AreaCounter.Core.Domain.Entities;

public class CircleEntity : IFigure 
{
    private readonly double _radius;
    public CircleEntity(double radius)
    {
        if (radius < 0)
            throw new ArgumentException("Радиус должен быть положительным");
        _radius = radius;
    }

    public double GetArea() 
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}