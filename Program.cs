using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AlphaListParser.AnnualRecording;
using AlphaListParser.Components.AlphalistDataTransformer;
using AlphaListParser.Components.AlphalistLoader;
using AlphaListParser.Components.AlphalistReader;
using AlphaListParser.Components.Constants;
using AlphaListParser.Components.TaxCodes;

namespace AlphaListParser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string mode = args[0];

            AlphalistConfig config = await ReadConfig();

            if (mode == AppConstants.QUARTERLY)
            {
                string sourceFile = args[1];

                await ExecuteQuarterlyUpload(config, sourceFile);
            }

            if (mode == AppConstants.TAX_CODES)
            {
                await TaxCodeExporter.ExportToCsv(config.DbPath);
            }

            if (mode == AppConstants.ANNUAL)
            {
                string sourceFile = args[1];

                int year = int.Parse(args[2]);

                await AnnualRecordingSeeder.SeedData(config, sourceFile, year);
            }

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

        public async static Task<int> ExecuteQuarterlyUpload(AlphalistConfig config, string sourceFile)
        {
            var records = AlphalistReader<AlphalistCSVModel>.Read(sourceFile);

            var transformed = AlphalistDataTransformer.Transform(records);

            await AlphalistLoader.WriteToTextFile(transformed, config);

            return 0;
        }
    }
}
