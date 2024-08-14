using Catharsium.Util.IO.Files.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
namespace Catharsium.Util.IO.Files.Csv;

[ExcludeFromCodeCoverage]
public class CsvWriter : ICsvWriter
{
    private readonly StreamWriter streamWriter;
    private readonly string separator;


    public CsvWriter(StreamWriter streamWriter, string separator = ",") {
        this.streamWriter = streamWriter;
        this.separator = separator;
    }


    public void WriteHeader<T>() {
        var type = typeof(T);
        this.WriteHeader(type.GetProperties());
    }


    public void WriteHeader<T>(IEnumerable<string> fields) {
        var type = typeof(T);
        var propertyInfos = type.GetProperties();
        var properties = fields
            .Select(f => propertyInfos.FirstOrDefault(p => p.Name == f))
            .Where(property => property != null)
            .ToList();
        this.WriteHeader(properties);
    }


    public void WriteHeader(IEnumerable<PropertyInfo> properties) {
        var propertyInfos = properties.ToArray();
        for(var i = 0; i < propertyInfos.Length; i++) {
            this.streamWriter.Write($"\"{propertyInfos[i].Name}\"");
            if(i < propertyInfos.Length - 1) {
                this.streamWriter.Write(this.separator);
            }
        }
    }


    public void WriteRecord<T>(T data) {
        var propertyInfos = typeof(T).GetProperties().ToArray();
        var values = propertyInfos.Select(p => typeof(T).GetProperty(p.Name)?.GetValue(data));
        var record = string.Join(",", values.Select(v => $"\"{v}\""));
        this.streamWriter.Write(record);
    }
}