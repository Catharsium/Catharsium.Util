namespace Catharsium.Util.IO.Files.Interfaces;

public interface ICsvFileWriter
{
    void WriteCsvFile<T>(string path, IEnumerable<T> data);
}