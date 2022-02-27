using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.OleDb;
using Dapper;
using System.Data.Odbc;
using AlphaListParser.Models;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace AlphaListParser.Components.TaxCodes
{
    public static class TaxCodeExporter
    {
        public static async Task<IEnumerable<TaxCode>> GetTaxCodes(string connectionString)
        {
            var connection = new OleDbConnection(connectionString);


            var results = await connection.QueryAsync<TaxCode>(@"
            select 
            atc_code Code,
            description,
            form_type FormType,
            rate
            from Reg_atcs order by atc_code");

            return results;
        }

        public static async Task<int> ExportToCsv(string connectionString)
        {
            var taxCodes = await GetTaxCodes(connectionString);

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string filename = "TaxCodes.csv";

            string path = @$"{desktop}\{filename}";

            using var writer = new StreamWriter(path);

            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteRecords(taxCodes);

            return 0;

        }


    }
}