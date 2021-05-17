namespace AlphaListParser.Components.AlphalistDataTransformer
{
    public class ExtractUnsanitizedTinBranchId
    {
        public static string Apply(string name)
        {
            string normalizedTin = NormalizeTin.Apply(name);

            int startingIndex = 9;

            int remainingLength = normalizedTin.Length - startingIndex;

            return normalizedTin.Substring(startingIndex, remainingLength);

        }
    }
}