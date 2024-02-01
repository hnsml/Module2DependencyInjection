using Module2DependencyInjection.Entities.EntitiesAnimals;
using Module2DependencyInjection.Entities.EntitiesFigures;
using Module2DependencyInjection.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2DependencyInjection.Services;

public class FigureFileService
{
    private readonly ISerializer<Figure> _serializer;

    public FigureFileService(ISerializer<Figure> serializer)
    {
        _serializer = serializer;
    }

    public void SaveToFile(Figure[] figures, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            _serializer.Serialize(writer, figures);
        }
    }

    public Figure[] LoadFromFile(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            return _serializer.Deserialize<Figure>(reader);
        }
    }
}