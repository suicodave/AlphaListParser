using System;
using System.Collections.Generic;
using System.Linq;

namespace AlphaListParser.Components.AlphalistDataTransformer
{
    public static class ExtractIndividualSqlStatement
    {
        public const string DateFormat = "yyyy-MM-dd";
        public static IEnumerable<string> Apply(IEnumerable<TransformedAlphalistModel> records, AlphalistConfig config)
        {
            string template = "insert into alphadtl (Form_type,Employer_tin,Employer_branch_code,Retrn_period,Schedule_num,Sequence_num,Registered_name,First_name,Last_name,Middle_name,Tin,Branch_code,Atc_code,Actual_amt_wthld,Income_payment,Tax_rate,Qrt_num,Quarterdate) values (";

            string dateFormat = $"{{^{config.CutOffDate.ToString(DateFormat)}}}";

            int quarterNumber = GetQuarterNumber(config.CutOffDate);

            string quarterDate = $"{{^{GetQuarterDate(config.CutOffDate).ToString(DateFormat)}}}";

            return records.Select(
                x => $@"{template}'{config.FormType}','{config.CompanyTin}','{config.CompanyBranch}',{dateFormat},'{config.ScheduleCode}',{x.Sequence},'{x.CorporateName}','{x.FirstName}','{x.LastName}','{x.MiddleName}','{x.BaseTin}','{x.BranchId}','{x.TaxCode}',{x.WithHoldingTax},{x.TaxBase},{x.TaxRate},{quarterNumber},{quarterDate})"
            );
        }

        public static int GetQuarterNumber(DateTime cutOffDate)
        {
            return (int)Math.Floor((double)(cutOffDate.Month + 2) / 3);
        }

        public static DateTime GetQuarterDate(DateTime cutOffDate)
        {
            int quarterNumber = GetQuarterNumber(cutOffDate);

            int quarterMonth = quarterNumber * 3;

            int quarterDays = DateTime.DaysInMonth(cutOffDate.Year, quarterMonth);

            return new DateTime(cutOffDate.Year, quarterMonth, quarterDays);
        }


    }
}