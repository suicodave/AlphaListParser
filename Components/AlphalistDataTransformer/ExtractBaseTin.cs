namespace AlphaListParser.Components.AlphalistDataTransformer
{
    public static class ExtractBaseTin
    {
        public static string Apply(string name)
        {
            string normalizedTin = NormalizeTin.Apply(name);

            return normalizedTin.Substring(0, 9);
        }
    }
}