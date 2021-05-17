using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AlphaListParser.Components.AlphalistDataTransformer;

namespace AlphaListParser.Components.AlphalistLoader
{
    public static class AlphalistLoader
    {
        public static async Task WriteToTextFile(IEnumerable<TransformedAlphalistModel> records, AlphalistConfig config)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            await DumpDebugData(records, desktopPath);


            await DumpIndividualQuery(records, desktopPath, config);

        }

        public static async Task DumpDebugData(IEnumerable<TransformedAlphalistModel> records, string path)
        {
            string filename = $"{Guid.NewGuid()}-alphalist debug.json";

            string fullPath = Path.Combine(path, filename);

            string contents = JsonSerializer.Serialize(records);

            await File.WriteAllTextAsync(fullPath, contents);
        }

        public static async Task DumpIndividualQuery(IEnumerable<TransformedAlphalistModel> records, string path, AlphalistConfig config)
        {
            string filename = $"{Guid.NewGuid()}-alphalist individual query.txt";

            string fullPath = Path.Combine(path, filename);

            var contents = ExtractIndividualSqlStatement.Apply(records, config);

            await File.WriteAllLinesAsync(fullPath, contents);
        }
    }
}