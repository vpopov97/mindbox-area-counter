using System.Reflection;

using AreaCounter.Core.Domain.Common;
using AreaCounter.Core.Application.Services;

namespace AreaCounter.Presentation;

public interface IFigureFactory
{
    IFigure CreateFigure(FigureType type, object[] arguments);
}

public class FigureFactory : IFigureFactory
{
    private static Dictionary<string, Type> _types = new Dictionary<string, Type>();

    public FigureFactory()
    {
        FillFigureTypes();
    }

    private void FillFigureTypes()
    {
        Assembly assembly = Assembly.Load("Domain");
        _types = assembly.GetTypes()
            .Where(t => t.IsClass && t.Namespace == "AreaCounter.Core.Domain.Entities")
            .ToDictionary(t => t.Name, t => t);
    }

    public IFigure CreateFigure(FigureType type, object[] constructorArguments)
    {
        string figureType = type.ToString() + "Entity";
        if (!_types.ContainsKey(figureType))
            throw new Exception("Неизвестный тип фигуры");

        Type t = _types[figureType];
        return Activator.CreateInstance(t, constructorArguments) as IFigure;
    }



    public static double GetArea(IFigure figure)
    {
        return new GeometryService(figure).GetArea();
    }
}