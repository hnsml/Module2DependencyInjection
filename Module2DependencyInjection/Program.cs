using Module2DependencyInjection.Entities;
using System.Data;
using System.Drawing;
using System.Text;
using Module2DependencyInjection.Repositories;
using Module2DependencyInjection.Services;
using Module2DependencyInjection.Serializers;
using Module2DependencyInjection.Entities.EntitiesAnimals;
using Module2DependencyInjection.Entities.EntitiesFigures;

namespace Module2DependencyInjection;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Task1();
        Task2();
        Task3();
        Task4();
    }

    static void Task1()
    {
        var consoleLogger = new ConsoleLogger();

        AnimalService snakeService = new AnimalService(new Snake(consoleLogger), consoleLogger);
        AnimalService catService = new AnimalService(new Cat(consoleLogger), consoleLogger);
        AnimalService goatService = new AnimalService(new Goat(consoleLogger), consoleLogger);

        Console.WriteLine("Всі тварини та їх звуки: (також цю інформацію записано в файл animals.txt)");
        snakeService.PrintInfo();
        catService.PrintInfo();
        goatService.PrintInfo();

        var fileLogger = new FileLogger("animals.txt");

        AnimalService snakeServicFile = new AnimalService(new Snake(fileLogger), fileLogger);
        AnimalService catServiceFile = new AnimalService(new Cat(fileLogger), fileLogger);
        AnimalService goatServiceFile = new AnimalService(new Goat(fileLogger), fileLogger);

        snakeServicFile.PrintInfo();
        catServiceFile.PrintInfo();
        goatServiceFile.PrintInfo();
    }

    static void Task2()
    {
        var xmlAnimalFileService = new AnimalFileService(new XmlSerializer<Animal>());
        var consoleLogger = new ConsoleLogger();

        var animals = new Animal[]
        {
            new Snake(consoleLogger),
            new Cat(consoleLogger),
            new Goat(consoleLogger),
        };

        xmlAnimalFileService.SaveToFile(animals, "animals.xml");
        Console.WriteLine("\nМасив всіх тварин сереалізовано в файл animals.xml");

        Console.WriteLine("\nДесереалізація масиву тварин з animals.xml:");
        var loadedAnimals = xmlAnimalFileService.LoadFromFile("animals.xml");
        foreach (var animal in loadedAnimals)
        {
            var loadedAnimalService = new AnimalService(animal, consoleLogger, xmlAnimalFileService);
            loadedAnimalService.PrintInfo();
        }

        var jsonAnimalFileService = new AnimalFileService(new JsonSerializer<Animal>());
        jsonAnimalFileService.SaveToFile(animals, "animals.json");
        Console.WriteLine("\nМасив всіх тварин сереалізовано в файл animals.json");

        Console.WriteLine("\nДесереалізація масиву тварин з animals.json:");
        var loadedJsonAnimals = jsonAnimalFileService.LoadFromFile("animals.json");
        foreach (var loadedAnimal in loadedAnimals)
        {
            var loadedAnimalService = new AnimalService(loadedAnimal, consoleLogger, jsonAnimalFileService);
            loadedAnimalService.PrintInfo();
        }
    }

    static void Task3()
    {
        var consoleLogger = new ConsoleLogger();

        FigureService circleService = new FigureService(new Circle(consoleLogger), consoleLogger);
        FigureService squareService = new FigureService(new Square(consoleLogger), consoleLogger);
        FigureService triangleService = new FigureService(new Triangle(consoleLogger), consoleLogger);
        FigureService rectangleService = new FigureService(new Module2DependencyInjection.Entities.EntitiesFigures.Rectangle(consoleLogger), consoleLogger);

        Console.WriteLine("\nВсі фігури та їх вигляд: (також цю інформацію записано в файл figures.txt)");
        circleService.PrintInfo();
        squareService.PrintInfo();
        triangleService.PrintInfo();
        rectangleService.PrintInfo();

        var fileLogger = new FileLogger("figures.txt");

        FigureService circleServicFile = new FigureService(new Circle(fileLogger), fileLogger);
        FigureService squareServiceFile = new FigureService(new Square(fileLogger), fileLogger);
        FigureService triangleServiceFile = new FigureService(new Triangle(fileLogger), fileLogger);
        FigureService rectangleServiceFile = new FigureService(new Module2DependencyInjection.Entities.EntitiesFigures.Rectangle(fileLogger), fileLogger);

        circleServicFile.PrintInfo();
        squareServiceFile.PrintInfo();
        triangleServiceFile.PrintInfo();
        rectangleServiceFile.PrintInfo();
    }

    static void Task4()
    {
        var xmlFiguresFileService = new FigureFileService(new XmlSerializer<Figure>());
        var consoleLogger = new ConsoleLogger();

        var figures = new Figure[]
        {
            new Circle(consoleLogger),
            new Square(consoleLogger),
            new Triangle(consoleLogger),
            new Module2DependencyInjection.Entities.EntitiesFigures.Rectangle(consoleLogger),
        };

        xmlFiguresFileService.SaveToFile(figures, "figures.xml");
        Console.WriteLine("\nМасив всіх фігур сереалізовано в файл figures.xml");

        Console.WriteLine("\nДесереалізація масиву фігур з figures.xml:");
        var loadedXmlFigures = xmlFiguresFileService.LoadFromFile("figures.xml");
        foreach (var figure in loadedXmlFigures)
        {
            var loadedFigureService = new FigureService(figure, consoleLogger, xmlFiguresFileService);
            loadedFigureService.PrintInfo();
        }

        var jsonFigureFileService = new FigureFileService(new JsonSerializer<Figure>());
        jsonFigureFileService.SaveToFile(figures, "figures.json");
        Console.WriteLine("\nМасив всіх фігур сереалізовано в файл figures.json");

        Console.WriteLine("\nДесереалізація масиву фігур з figures.json:");
        var loadedJsonFigures = jsonFigureFileService.LoadFromFile("figures.json");
        foreach (var figure in loadedJsonFigures)
        {
            var loadedFigureService = new FigureService(figure, consoleLogger, jsonFigureFileService);
            loadedFigureService.PrintInfo();
        }
    }
}