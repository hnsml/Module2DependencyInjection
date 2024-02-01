using Module2DependencyInjection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2DependencyInjection.Entities.EntitiesFigures;

public class Triangle : Figure
{
    public Triangle() : base(null)
    {
    }

    public Triangle(ILogger logger) : base(logger)
    {
        Name = "Трикутник";
        View = "▲";
    }
}