using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AlphaListParser.Components.AlphalistReader;

namespace AlphaListParser.Components.AlphalistDataTransformer
{
    public static class AlphalistDataTransformer
    {
        public static IEnumerable<TransformedAlphalistModel> Transform(IEnumerable<AlphalistCSVModel> csvRecords)

        {
            int itemCount = csvRecords.Count();

            ICollection<TransformedAlphalistModel> records = new List<TransformedAlphalistModel>();

            for (int i = 0; i < itemCount; i++)
            {
                var x = csvRecords.ElementAt(i);

                records.Add(new TransformedAlphalistModel
                {
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    CorporateName = x.CorporateName,
                    TaxIdentificationNumber = x.TaxIdentificationNumber,
                    TaxCode = TaxCodeCleaner.Apply(x.TaxCode),
                    TaxBase = x.TaxBase,
                    WithHoldingTax = x.WithHoldingTax,
                    TaxRate = x.TaxRate,
                    NormalizedTin = NormalizeTin.Apply(x.TaxIdentificationNumber),
                    UnsanitizedBranchId = ExtractUnsanitizedTinBranchId.Apply(x.TaxIdentificationNumber),
                    Sequence = i + 1

                });
            }

            return records;
        }


    }
}