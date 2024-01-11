using AreaCounter.Core.Domain.Common;


namespace AreaCounter.Core.Application.Services;
public class GeometryService
{
    private readonly IFigure _figure;
    public GeometryService(IFigure figure)
    {
        _figure = figure;
    }

    public double GetArea () {
        return _figure.GetArea();
    }
}