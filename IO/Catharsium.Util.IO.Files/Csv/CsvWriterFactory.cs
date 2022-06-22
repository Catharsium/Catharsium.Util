using Catharsium.Util.IO.Files.Interfaces;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Catharsium.Util.IO.Files.Csv;

[ExcludeFromCodeCoverage]
public class CsvWriterFactory : ICsvWriterFactory
{
    public ICsvWriter Create(StreamWriter streamWriter, string separator = ",")
    {
        return new CsvWriter(streamWriter, separator);
    }
}