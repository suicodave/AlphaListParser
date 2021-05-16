using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace AlphaListParser.Components.AlphalistReader
{
    public static class AlphalistReader<Model> where Model : class
    {
        public static IEnumerable<Model> Read(string filePath)
        {
            IEnumerable<Model> records;

            var readerConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            };

            using (var streamReader = new StreamReader(filePath))
            using (var csv = new CsvReader(streamReader, readerConfig))
            {
                records = csv.GetRecords<Model>().ToList();
            }

            return records;
        }
    }
}