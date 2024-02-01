using Module2DependencyInjection.Entities.EntitiesAnimals;
using Module2DependencyInjection.Repositories;
namespace Module2DependencyInjection.Services;

public class AnimalService
{
    private readonly Animal animal;
    private readonly ILogger logger;
    private readonly AnimalFileService fileService;

    public AnimalService(Animal animal, ILogger logger)
    {
        this.animal = animal;
        this.logger = logger;
    }

    public AnimalService(Animal animal, ILogger logger, AnimalFileService fileService)
    {
        this.animal = animal;
        this.logger = logger;
        this.fileService = fileService;
    }

    public void PrintInfo()
    {
        logger.Log($"Назва: {animal.Name}");
        logger.Log($"Звук: {animal.Sound}");
    }
}