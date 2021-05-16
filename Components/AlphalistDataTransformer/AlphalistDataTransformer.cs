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
            return csvRecords.Select(
                x => new TransformedAlphalistModel
                {
                    CorporateName = CleanName.Apply(x.CorporateName),
                    FirstName = CleanName.Apply(x.FirstName),
                    MiddleName = CleanName.Apply(x.MiddleName),
                    LastName = CleanName.Apply(x.LastName),
                    TaxIdentificationNumber = x.TaxIdentificationNumber,
                    TaxCode = x.TaxCode,
                    TaxBase = x.TaxBase,
                    WithHoldingTax = x.WithHoldingTax,
                    TaxRate = x.TaxRate,
                    NormalizedTin = "To Be Added",
                    BaseTin = "To Be Added",
                    BranchId = "To Be Added",
                    Sequence = 999

                }
            );
        }


    }
}