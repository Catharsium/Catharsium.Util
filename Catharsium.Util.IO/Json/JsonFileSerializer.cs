using Catharsium.Util.IO.Interfaces;
using System.IO;
using System.Text.Json;

namespace Catharsium.Util.IO.Json
{
    public class JsonFileSerializer
    {
        public T ReadAs<T>(string file)
        {
            var jsonString = File.ReadAllText(file);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}