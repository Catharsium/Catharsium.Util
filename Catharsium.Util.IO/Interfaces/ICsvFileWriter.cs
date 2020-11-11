using System.Collections.Generic;

namespace Catharsium.Util.IO.Interfaces
{
    public interface ICsvFileWriter
    {
        void WriteCsvFile<T>(string path, IEnumerable<T> data);
    }
}