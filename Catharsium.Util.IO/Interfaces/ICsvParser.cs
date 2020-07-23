using System.Collections.Generic;

namespace Catharsium.Util.IO.Interfaces
{
    public interface ICsvParser
    {
        List<List<string>> Parse(IEnumerable<string> records, bool skipFirst = true, char deliminator = ',');
        List<string> Parse(string record, char deliminator = ',');
    }
}