using System.Text.RegularExpressions;

namespace AlphaListParser.Components.AlphalistDataTransformer
{
    public static class NameCleaner
    {
        public static string Apply(string name)
        {
            name = RemoveSpecialCharacters(name);

            name = RemoveEnye(name);

            name = RemoveAmpersand(name);

            name = RemoveExtraWhiteSpace(name);

            return name;
        }

        public static string RemoveSpecialCharacters(string name)
        {
            return Regex.Replace(name, @"[^a-zA-Z0-9 ]", "");
        }

        public static string RemoveEnye(string name)
        {
            return name.Replace("ñ", "n")
            .Replace("Ñ", "n");
        }

        public static string RemoveAmpersand(string name)
        {
            return name.Replace("&", " and ");
        }

        public static string RemoveExtraWhiteSpace(string name)
        {
            name = Regex.Replace(name, @"/^\s+|\s+$|\s+(?=\s)", "");

            return name.Trim();
        }

        public static string NumbersOnly(string name)
        {
            return Regex.Replace(name, @"[^0-9 ]", "");
        }


        public static string RemoveWhiteSpace(string name)
        {
            return name.Replace(" ", "");
        }



    }
}