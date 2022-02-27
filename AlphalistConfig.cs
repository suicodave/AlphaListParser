using System;

namespace AlphaListParser
{
    public class AlphalistConfig
    {
        public string FormType { get; set; }

        public string CompanyTin { get; set; }

        public string CompanyBranch { get; set; }

        public DateTime CutOffDate { get; set; }

        public string ScheduleCode { get; set; }

        public string DbPath { get; set; }

        public string AnnualSchedule { get; set; }

        public string AnnualFormType { get; set; }

    }
}