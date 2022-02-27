using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AlphaListParser.Components.AlphalistDataTransformer;
using AlphaListParser.Components.AlphalistReader;
using CsvHelper;
using CsvHelper.Configuration;
using Dapper;

namespace AlphaListParser.AnnualRecording
{
    public static class AnnualRecordingSeeder
    {

        public static async Task<int> SeedData(AlphalistConfig config, string path, int year)
        {
            DateTime returnPeriod = new DateTime(year, 12, 31);

            var items = AlphalistReader<AnnualItemModel>.Read(path);

            await Truncate(config.DbPath);

            int count = items.Count();

            foreach (var item in items)
            {
                await CreateEntry(config, item, returnPeriod);
            }

            return 1;
        }


        private static async Task<int> CreateEntry(AlphalistConfig config, AnnualItemModel entry, DateTime returnPeriod)
        {
            var connection = new OleDbConnection(config.DbPath);

            string dateFormat = $"{{^{returnPeriod.ToString("yyyy-MM-dd")}}}";

            string template = @"insert into alphadtl (
                employment_from,
                employment_to,
                status_code,
                region_num,
                subs_filing,
                EXMPN_CODE,
                FACTOR_USED,
                PRES_TAXABLE_SALARIES,
                PRES_TAXABLE_13TH_MONTH,
                PRES_TAX_WTHLD,
                PRES_NONTAX_SALARIES,
                PRES_NONTAX_13TH_MONTH,
                PREV_TAXABLE_SALARIES,
                prev_taxable_13th_month,
                prev_tax_wthld,
                prev_nontax_salaries,
                prev_nontax_13th_month,
                pres_nontax_sss_gsis_oth_cont,
                prev_nontax_sss_gsis_oth_cont,
                over_wthld,
                amt_wthld_dec,
                exmpn_amt,
                tax_due,
                heath_premium,
                fringe_benefit,
                monetary_value,
                net_taxable_comp_income,
                gross_comp_income,
                prev_nontax_de_minimis,
                prev_total_nontax_comp_income,
                prev_taxable_basic_salary,
                pres_nontax_de_minimis,
                pres_taxable_basic_salary,
                pres_total_comp,
                prev_pres_total_taxable,
                pres_total_nontax_comp_income,
                prev_nontax_gross_comp_income,
                prev_nontax_basic_smw,
                prev_nontax_holiday_pay,
                prev_nontax_overtime_pay,
                prev_nontax_night_diff,
                prev_nontax_hazard_pay,
                pres_nontax_gross_comp_income,
                pres_nontax_basic_smw_day,
                pres_nontax_basic_smw_month,
                pres_nontax_basic_smw_year,
                pres_nontax_holiday_pay,
                pres_nontax_overtime_pay,
                pres_nontax_night_diff,
                prev_pres_total_comp_income,
                pres_nontax_hazard_pay,
                total_nontax_comp_income,
                total_taxable_comp_income,
                prev_total_taxable,
                nontax_basic_sal,
                tax_basic_sal,
                qrt_num,
                quarterdate,
                nationality,
                reason_separation,
                employment_status,
                address1,
                address2,
                atc_desc,
                date_death,
                date_wtheld,
                Form_type,Employer_tin,Employer_branch_code,Retrn_period,Schedule_num,Sequence_num,Registered_name,First_name,Last_name,Middle_name,Tin,Branch_code,Atc_code,Actual_amt_wthld,Income_payment,Tax_rate) values (
                    {//},
                    {//},
                    '','','','',0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,{//},'','','','','','',{//},{//},
                ";

            string sql = @$"{template}'{config.AnnualFormType}','{config.CompanyTin}','{config.CompanyBranch}',{dateFormat},'{config.AnnualSchedule}',{entry.Sequence},'{entry.CorporateName}','{entry.FirstName}','{entry.LastName}','{entry.MiddleName}','{entry.BaseTin}','{entry.BranchId}','{entry.TaxCode}',{entry.WithHoldingTax},{entry.TaxBase},{entry.TaxRate})";

            Console.WriteLine($@"Creating Sequence: {entry.Sequence}");

            return await connection.ExecuteAsync(sql);
        }

        private static async Task<int> Truncate(string connectionString)
        {
            var connection = new OleDbConnection(connectionString);

            await connection.OpenAsync();

            string[] commands = {
                "set exclusive on",
                "Delete From alphadtl",
                "PACK"
            };

            foreach (var statement in commands)
            {
                var command = new OleDbCommand(statement);

                command.Connection = connection;

                command.ExecuteNonQuery();
            }

            await connection.CloseAsync();

            return 1;
        }

    }
}