using System;

namespace AlphaListParser.Components.AlphalistDataTransformer
{
    public static class NormalizeTin
    {
        public static string Apply(string name)
        {
            return NameCleaner.RemoveSpecialCharacters(name);
        }


        
    }
}