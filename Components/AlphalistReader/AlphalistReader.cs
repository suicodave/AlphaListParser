using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace AlphaListParser.Components.AlphalistReader
{
    public static class AlphalistReader<Model> where Model : class
    {
        public static IEnumerable<Model> Read(string filePath)
        {

            var readerConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            };

            using var streamReader = new StreamReader(filePath);

            using var csv = new CsvReader(streamReader, readerConfig);

            return csv.GetRecords<Model>().ToList();

        }
    }
}