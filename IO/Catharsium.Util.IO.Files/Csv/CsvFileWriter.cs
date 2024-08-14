using Catharsium.Util.IO.Files.Interfaces;
using System.Text;

namespace Catharsium.Util.IO.Files.Csv;

public class CsvFileWriter : ICsvFileWriter
{
    private readonly ICsvWriter csvWriter;


    public CsvFileWriter(ICsvWriter csvWriter) {
        this.csvWriter = csvWriter;
    }


    public void WriteCsvFile<T>(string path, IEnumerable<T> data) {
        using var sw = new StreamWriter(path, false, new UTF8Encoding(true));
        this.csvWriter.WriteHeader<T>();
        foreach(var record in data) {
            this.csvWriter.WriteRecord(record);
        }
    }
}