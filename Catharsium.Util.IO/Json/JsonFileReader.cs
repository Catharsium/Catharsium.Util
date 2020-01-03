using Catharsium.Util.IO.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;

namespace Catharsium.Util.IO.Json
{
    [ExcludeFromCodeCoverage]
    public class JsonFileReader : IJsonFileReader
    {
        public T ReadFrom<T>(string file)
        {
            var jsonString = File.ReadAllText(file);
            return JsonSerializer.Deserialize<T>(jsonString, new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}