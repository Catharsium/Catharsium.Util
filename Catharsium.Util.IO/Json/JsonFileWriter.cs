using Catharsium.Util.IO.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;

namespace Catharsium.Util.IO.Json
{
    [ExcludeFromCodeCoverage]
    public class JsonFileWriter : IJsonFileWriter
    {
        public void Write(object data, string file)
        {
            var serialized = JsonSerializer.Serialize(data);
            File.WriteAllText(file, serialized);
        }
    }
}