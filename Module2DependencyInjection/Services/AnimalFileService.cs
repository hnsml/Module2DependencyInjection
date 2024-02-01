using Module2DependencyInjection.Repositories;
using System.Xml.Serialization;
using Module2DependencyInjection.Serializers;
using Module2DependencyInjection.Entities.EntitiesAnimals;

namespace Module2DependencyInjection.Services;

public class AnimalFileService
{
    private readonly ISerializer<Animal> _serializer;

    public AnimalFileService(ISerializer<Animal> serializer)
    {
        _serializer = serializer;
    }

    public void SaveToFile(Animal[] animals, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            _serializer.Serialize(writer, animals);
        }
    }

    public Animal[] LoadFromFile(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            return _serializer.Deserialize<Animal>(reader);
        }
    }
}
