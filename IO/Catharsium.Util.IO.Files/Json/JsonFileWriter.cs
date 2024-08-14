using Catharsium.Util.IO.Files.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Catharsium.Util.IO.Files.Json;

[ExcludeFromCodeCoverage]
public class JsonFileWriter : IJsonFileWriter
{
    readonly JsonSerializerOptions options = new() {
        WriteIndented = true
    };


    public void Write(object data, string file) {

        var serialized = JsonSerializer.Serialize(data, options);
        File.WriteAllText(file, serialized);
    }


    public void Write(object data, IFile file) {
        this.Write(data, file.FullName);
    }
}