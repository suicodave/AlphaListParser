using System;

namespace AlphaListParser.Components.AlphalistDataTransformer
{
    public static class NormalizeTin
    {
        public static string Apply(string name)
        {
            name = NameCleaner.NumbersOnly(name);

            name = NameCleaner.RemoveWhiteSpace(name);

            return NameCleaner.Apply(name);
        }



    }
}