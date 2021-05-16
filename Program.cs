using System;
using System.Text.Json;
using AlphaListParser.Components.AlphalistReader;

namespace AlphaListParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = args[0];

            var alphaListReader = new AlphalistReader<AlphalistModel>();


            var records = alphaListReader.Read(filePath);


            foreach (var item in records)
            {
                Console.WriteLine(JsonSerializer.Serialize(item));
            }
        }
    }
}
