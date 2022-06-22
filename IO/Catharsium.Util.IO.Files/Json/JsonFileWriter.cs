using Catharsium.Util.IO.Files.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
namespace Catharsium.Util.IO.Files.Json;

[ExcludeFromCodeCoverage]
public class JsonFileWriter : IJsonFileWriter
{
    public void Write(object data, string file)
    {
        var options = new JsonSerializerOptions {
            WriteIndented = true
        };
        var serialized = JsonSerializer.Serialize(data, options);
        File.WriteAllText(file, serialized);
    }


    public void Write(object data, IFile file)
    {
        this.Write(data, file.FullName);
    }
}