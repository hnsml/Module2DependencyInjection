using Module2DependencyInjection.Entities;
using Module2DependencyInjection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module2DependencyInjection.Entities.EntitiesFigures;

public class Rectangle : Figure
{
    public Rectangle() : base(null)
    {
    }

    public Rectangle(ILogger logger) : base(logger)
    {
        Name = "Прямокутник";
        View = "■■";
    }
}
