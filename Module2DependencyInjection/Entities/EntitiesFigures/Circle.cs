using Module2DependencyInjection.Entities;
using Module2DependencyInjection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module2DependencyInjection.Entities.EntitiesFigures;
public class Circle : Figure
{
    public Circle() : base(null)
    {
    }

    public Circle(ILogger logger) : base(logger)
    {
        Name = "Коло";
        View = "●"; //■▲
    }
}
