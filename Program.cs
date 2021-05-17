using System;
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
            string filePath = args[0];

            var records = AlphalistReader<AlphalistCSVModel>.Read(filePath);

            var transformed = AlphalistDataTransformer.Transform(records);

            await AlphalistLoader.WriteToTextFile(transformed);

        }
    }
}
