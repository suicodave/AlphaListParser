using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AlphaListParser.Components.AlphalistReader;

namespace AlphaListParser.Components.AlphalistDataTransformer
{
    public class AlphalistDataTransformer
    {
        public IEnumerable<TransformedAlphalistModel> Transform(IEnumerable<AlphalistCSVModel> csvRecords)

        {
            return csvRecords.Select(
                x => new TransformedAlphalistModel
                {
                    CorporateName = x.CorporateName,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
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