using System.Xml.Serialization;

namespace Module2DependencyInjection.Serializers;

public class XmlSerializer<T> : ISerializer<T> where T : class
{
    private readonly XmlSerializer _serializer;

    public XmlSerializer()
    {
        _serializer = new XmlSerializer(typeof(T[]));
    }

    public void Serialize<T>(TextWriter writer, T[] entities)
    {
        _serializer.Serialize(writer, entities);
    }

    public T[] Deserialize<T>(TextReader reader)
    {
        return (T[])_serializer.Deserialize(reader);
    }
}
