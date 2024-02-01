using Module2DependencyInjection.Repositories;

namespace Module2DependencyInjection.Entities.EntitiesAnimals;

public class Cat : Animal
{
    public Cat() : base(null)
    {
    }

    public Cat(ILogger logger) : base(logger)
    {
        Name = "Котик";
        Sound = "Мяу! Мяу! Мяу!";
    }
}