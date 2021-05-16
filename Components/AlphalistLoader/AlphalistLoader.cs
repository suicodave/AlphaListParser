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
        public static async Task WriteToTextFile(IEnumerable<TransformedAlphalistModel> records)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string filename = $"{Guid.NewGuid()}-alphalist.json";

            string fullPath = Path.Combine(desktopPath, filename);

            string contents = JsonSerializer.Serialize(records);

            await File.WriteAllTextAsync(fullPath, contents);
        }
    }
}