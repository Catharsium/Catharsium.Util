using System.IO;

namespace Catharsium.Util.IO.Interfaces
{
    public interface ICsvWriterFactory
    {
        ICsvWriter Create(StreamWriter streamWriter, string separator = ",");
    }
}