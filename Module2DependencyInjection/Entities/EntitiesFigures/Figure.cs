using Module2DependencyInjection.Entities;
using Module2DependencyInjection.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Module2DependencyInjection.Entities.EntitiesFigures;

[Serializable]
[XmlInclude(typeof(Circle))]
[XmlInclude(typeof(Square))]
[XmlInclude(typeof(Triangle))]
[XmlInclude(typeof(Rectangle))]

public class Figure
{
    private readonly ILogger logger;

    public string Name { get; set; }

    public string View { get; set; }

    [JsonConstructor]
    protected Figure()
    {
    }

    public Figure(ILogger logger)
    {
        this.logger = logger;
    }
}