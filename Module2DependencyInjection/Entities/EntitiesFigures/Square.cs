using Module2DependencyInjection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2DependencyInjection.Entities.EntitiesFigures;

public class Square : Figure
{
    public Square() : base(null)
    {
    }

    public Square(ILogger logger) : base(logger)
    {
        Name = "Квадрат";
        View = "■"; //■▲
    }
}