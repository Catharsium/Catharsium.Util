using Catharsium.Util.IO.Files.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
namespace Catharsium.Util.IO.Files.Json;

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


    public T ReadFrom<T>(IFile file)
    {
        return this.ReadFrom<T>(file.FullName);
    }
}