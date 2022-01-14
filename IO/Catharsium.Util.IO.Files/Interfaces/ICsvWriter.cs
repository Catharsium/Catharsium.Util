using System.Reflection;
namespace Catharsium.Util.IO.Files.Interfaces;

public interface ICsvWriter
{
    void WriteHeader<T>();

    void WriteHeader<T>(IEnumerable<string> fields);

    void WriteHeader(IEnumerable<PropertyInfo> properties);

    void WriteRecord<T>(T data);
}