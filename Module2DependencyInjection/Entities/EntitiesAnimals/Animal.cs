using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Module2DependencyInjection.Repositories;

namespace Module2DependencyInjection.Entities.EntitiesAnimals;

[Serializable]
[XmlInclude(typeof(Snake))]
[XmlInclude(typeof(Cat))]
[XmlInclude(typeof(Goat))]

public class Animal
{
    private readonly ILogger logger;

    public string Name { get; set; }

    public string Sound { get; set; }

    [JsonConstructor]
    protected Animal()
    {
    }

    public Animal(ILogger logger)
    {
        this.logger = logger;
    }
}