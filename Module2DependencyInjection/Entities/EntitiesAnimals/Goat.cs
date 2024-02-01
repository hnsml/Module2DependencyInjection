using Module2DependencyInjection.Repositories;

namespace Module2DependencyInjection.Entities.EntitiesAnimals;

public class Goat : Animal
{
    public Goat() : base(null)
    {
    }

    public Goat(ILogger logger) : base(logger)
    {
        Name = "Коза";
        Sound = "Мее! Мее! Меееееееееееееее!";
    }
}
