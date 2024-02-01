using Module2DependencyInjection.Entities.EntitiesFigures;
using Module2DependencyInjection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2DependencyInjection.Services;

public class FigureService 
{
    private readonly Figure figure;
    private readonly ILogger logger;
    private readonly FigureFileService fileService;

    public FigureService(Figure figure, ILogger logger)
    {
        this.figure = figure;
        this.logger = logger;
    }

    public FigureService(Figure figure, ILogger logger, FigureFileService fileService)
    {
        this.figure = figure;
        this.logger = logger;
        this.fileService = fileService;
    }

    public void PrintInfo()
    {
        logger.Log($"Назва: {figure.Name}");
        logger.Log($"Вигляд: {figure.View}");
    }
}