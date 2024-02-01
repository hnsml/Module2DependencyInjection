using System.IO;
using System.Text;
using System.Text.Json;

namespace Module2DependencyInjection.Serializers
{
    public class JsonSerializer<T> : ISerializer<T> where T : class
    {
        private readonly JsonSerializerOptions _serializerOptions;

        public JsonSerializer(JsonSerializerOptions serializerOptions = null)
        {
            _serializerOptions = serializerOptions ?? new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }

        public void Serialize<T>(TextWriter writer, T[] entities)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var utf8JsonWriter = new Utf8JsonWriter(memoryStream, new JsonWriterOptions { Indented = _serializerOptions.WriteIndented }))
                {
                    JsonSerializer.Serialize(utf8JsonWriter, entities, _serializerOptions);
                }

                // Writing to the provided TextWriter
                var jsonString = Encoding.UTF8.GetString(memoryStream.ToArray());
                writer.Write(jsonString);
            }
        }

        public T[] Deserialize<T>(TextReader reader)
        {
            using (var jsonDocument = JsonDocument.Parse(reader.ReadToEnd()))
            {
                return JsonSerializer.Deserialize<T[]>(jsonDocument.RootElement.GetRawText(), _serializerOptions);
            }
        }
    }
}
