using Catharsium.Util.IO.Files.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Catharsium.Util.IO.Files.Json;

[ExcludeFromCodeCoverage]
public class JsonFileReader : IJsonFileReader
{
    public JsonSerializerOptions SerializerOptions { get; }


    public JsonFileReader() {
        this.SerializerOptions = new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        };
    }


    public T ReadFrom<T>(string file) {
        using var reader = new StreamReader(file);
        var jsonString = reader.ReadToEnd();
        return JsonSerializer.Deserialize<T>(jsonString, this.SerializerOptions);
    }


    public T ReadFrom<T>(IFile file) {
        return this.ReadFrom<T>(file.FullName);
    }
}