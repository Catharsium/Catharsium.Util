using System.IO;

namespace Catharsium.Util.IO.Files.Interfaces;

public interface ICsvWriterFactory
{
    ICsvWriter Create(StreamWriter streamWriter, string separator = ",");
}