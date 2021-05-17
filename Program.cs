using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AlphaListParser.Components.AlphalistDataTransformer;
using AlphaListParser.Components.AlphalistLoader;
using AlphaListParser.Components.AlphalistReader;

namespace AlphaListParser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string sourceFile = args[0];

            var records = AlphalistReader<AlphalistCSVModel>.Read(sourceFile);

            var transformed = AlphalistDataTransformer.Transform(records);

            AlphalistConfig config = await ReadConfig();

            await AlphalistLoader.WriteToTextFile(transformed, config);

        }

        static async Task<AlphalistConfig> ReadConfig()
        {
            string filename = "alphalist.config.json";

            var programPath = System.AppContext.BaseDirectory;

            var configFile = Path.Combine(programPath, filename);

            JsonSerializerOptions jsonOption = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            AlphalistConfig config = JsonSerializer.Deserialize<AlphalistConfig>(await File.ReadAllTextAsync(configFile), jsonOption);

            return config;
        }
    }
}
