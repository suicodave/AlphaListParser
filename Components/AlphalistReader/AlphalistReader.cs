using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace AlphaListParser.Components.AlphalistReader
{
    public class AlphalistReader<Model> where Model : class
    {
        public IEnumerable<Model> Read(string filePath)
        {
            IEnumerable<Model> records;

            using (var streamReader = new StreamReader(filePath))
            using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<Model>().ToList();
            }

            return records;
        }
    }
}