using Catharsium.Util.IO.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Catharsium.Util.IO.Csv
{
    public class CsvFileWriter : ICsvFileWriter
    {
        private readonly ICsvWriter csvWriter;


        public CsvFileWriter(ICsvWriter csvWriter)
        {
            this.csvWriter = csvWriter;
        }


        public void WriteCSVFile<T>(string path, IEnumerable<T> data)
        {
            using (var sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            {
                this.csvWriter.WriteHeader<T>();
                foreach (var record in data)
                {
                    this.csvWriter.WriteRecord(record);
                }
            }
        }
    }
}