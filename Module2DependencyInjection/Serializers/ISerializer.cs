using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2DependencyInjection.Serializers;

public interface ISerializer<T> where T : class
{
    void Serialize<T>(TextWriter writer, T[] entities);

    T[] Deserialize<T>(TextReader reader);
}
