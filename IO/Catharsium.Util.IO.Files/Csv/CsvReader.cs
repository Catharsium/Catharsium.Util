using Catharsium.Util.IO.Files.Interfaces;
using System.Text;
namespace Catharsium.Util.IO.Files.Csv
{
    public class CsvReader : ICsvReader
    {
        public List<List<string>> Parse(IEnumerable<string> records, bool skipFirst = true, char deliminator = ',') {
            var realRecords = skipFirst ? records.Skip(1) : records;
            return realRecords.Select(record => this.Parse(record, deliminator)).ToList();
        }


        public List<string> Parse(string record, char deliminator = ',') {
            var result = new List<string>();
            if(record == null) {
                return result;
            }

            var columnStarted = false;
            var currentColumn = new StringBuilder();
            foreach(var character in record) {
                if(character == '"') {
                    columnStarted = !columnStarted;
                }

                else if(character == deliminator) {
                    if(!columnStarted) {
                        result.Add(currentColumn.ToString());
                        currentColumn = new StringBuilder();
                    }
                    else {
                        currentColumn.Append(character);
                    }
                }

                else {
                    currentColumn.Append(character);
                }
            }

            result.Add(currentColumn.ToString());

            return result;
        }
    }
}