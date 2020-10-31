﻿using System.Collections.Generic;
using System.Linq;
using Catharsium.Util.IO.Interfaces;

namespace Catharsium.Util.IO.Csv
{
    public class CsvReader : ICsvReader
    {
        public List<List<string>> Parse(IEnumerable<string> records, bool skipFirst = true, char deliminator = ',')
        {
            var realRecords = skipFirst ? records.Skip(1) : records;
            return realRecords.Select(record => this.Parse(record, deliminator)).ToList();
        }


        public List<string> Parse(string record, char deliminator = ',')
        {
            var result = new List<string>();
            if (record == null) {
                return result;
            }

            var columnStarted = false;
            var currentColumn = "";
            foreach (var character in record) {
                if (character == '"') {
                    columnStarted = !columnStarted;
                }

                else if (character == deliminator) {
                    if (!columnStarted) {
                        result.Add(currentColumn);
                        currentColumn = "";
                    }
                    else {
                        currentColumn += character;
                    }
                }

                else {
                    currentColumn += character;
                }
            }

            result.Add(currentColumn);

            return result;
        }
    }
}