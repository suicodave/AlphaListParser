using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaListParser.Models
{
    public class TaxCode
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public decimal Rate { get; set; }

        public string FormType { get; set; }

    }
}