using AlphaListParser.Components.AlphalistReader;

namespace AlphaListParser.Components.AlphalistDataTransformer
{
    public class TransformedAlphalistModel : AlphalistCSVModel
    {
        public string NormalizedTin { get; set; }

        public string UnsanitizedBranchId { get; set; }


    }
}