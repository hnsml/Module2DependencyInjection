using Module2DependencyInjection.Repositories;

namespace Module2DependencyInjection.Entities.EntitiesAnimals;

public class Snake : Animal
{
    public Snake() : base(null)
    {
    }

    public Snake(ILogger logger) : base(logger)
    {
        Name = "Змія";
        Sound = "Ссс! Ссс! Ссс!";
    }
}
